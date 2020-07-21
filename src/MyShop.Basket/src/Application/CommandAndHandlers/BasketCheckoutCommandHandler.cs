using MediatR;
using Microsoft.Extensions.Logging;
using MyShop.Basket.Application.IntegrationEvents.Events;
using MyShop.Basket.Infrastructure.Repository;
using MyShop.EventBus.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyShop.Basket.Application.CommandAndHandlers
{
    public class BasketCheckoutCommandHandler : IRequestHandler<BasketCheckoutCommand, bool>
    {
        private readonly IBasketRepository _repository;
        private readonly ILogger<BasketCheckoutCommandHandler> _logger;
        private readonly IEventBus _eventBus;

        public BasketCheckoutCommandHandler(IBasketRepository repository, ILogger<BasketCheckoutCommandHandler> logger,
            IEventBus eventBus)
        {
            _repository = repository;
            _logger = logger;
            _eventBus = eventBus;
        }
        public async Task<bool> Handle(BasketCheckoutCommand request, CancellationToken cancellationToken)
        {

            var basket = await _repository.GetBasketAsync(request.BuyerId.ToString());

            if (basket.BasketItems.Count == 0)
            {
                return false;
            }

            var eventMessage = new UserCheckoutAcceptedIntegrationEvent(request.BuyerId, request.UserName, request.Address.City,
                request.Address.Street, request.Address.State, request.Address.Country, request.Address.ZipCode, request.PaymentMethod.CardNumber,
                request.PaymentMethod.CardHolderName, request.PaymentMethod.CardExpiration, request.PaymentMethod.CardSecurityNumber,
                request.PaymentMethod.CardTypeId, request.RequestId, basket.BasketItems);

            try
            {
                _logger.LogInformation("----- Publishing integration event: {IntegrationEventId} from {AppName} - ({@IntegrationEvent})", eventMessage.Id, Program.AppName, eventMessage);

                _eventBus.Publish(eventMessage);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex, "ERROR Publishing integration event: {IntegrationEventId} from {AppName}", eventMessage.Id, Program.AppName);
                throw;
            }

            return true;
        }
    }
}
