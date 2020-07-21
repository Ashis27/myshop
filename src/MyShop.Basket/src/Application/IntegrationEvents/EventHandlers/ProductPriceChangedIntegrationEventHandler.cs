using Microsoft.Extensions.Logging;
using MyShop.Basket.Application.CommandAndHandlers;
using MyShop.Basket.Application.IntegrationEvents.Events;
using MyShop.Basket.Infrastructure.Repository;
using MyShop.EventBus.Intefaces;
using MyShop.EventBus.Integration;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Basket.Application.IntegrationEvents.EventHandlers
{
    public class ProductPriceChangedIntegrationEventHandler : IIntegrationEventHandler<ProductPriceChangeIntegrationEvent>
    {
        private readonly ILogger<ProductPriceChangedIntegrationEventHandler> _logger;
        private readonly IBasketRepository _repository;

        public ProductPriceChangedIntegrationEventHandler(ILogger<ProductPriceChangedIntegrationEventHandler> logger,
            IBasketRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task Handle(ProductPriceChangeIntegrationEvent @event)
        {
            using (LogContext.PushProperty("IntegrationEventContext", $"{@event.Id}-{Program.AppName}"))
            {
                _logger.LogInformation("----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})", @event.Id, Program.AppName, @event);

                var userIds = _repository.GetUsers();

                foreach (var id in userIds)
                {
                    var basket = await _repository.GetBasketAsync(id);

                    await UpdatePriceInBasketItems(@event.ProductId, @event.NewPrice, @event.OldPrice, basket);
                }
            }
        }
        private async Task UpdatePriceInBasketItems(int productId, decimal newPrice, decimal oldPrice, BasketCommand basket)
        {
            string match = productId.ToString();
            var itemsToUpdate = basket?.BasketItems?.Where(x => x.ProductId == match).ToList();

            if (itemsToUpdate != null)
            {
                _logger.LogInformation("----- ProductPriceChangedIntegrationEventHandler - Updating items in basket for user: {BuyerId} ({@Items})", basket.BuyerId, itemsToUpdate);

                foreach (var item in itemsToUpdate)
                {
                    if (item.UnitPrice == oldPrice)
                    {
                        var originalPrice = item.UnitPrice;
                        item.UnitPrice = newPrice;
                        item.OldUnitPrice = originalPrice;
                    }
                }
                await _repository.UpdateBasketAsync(basket);
            }
        }
    }
}
