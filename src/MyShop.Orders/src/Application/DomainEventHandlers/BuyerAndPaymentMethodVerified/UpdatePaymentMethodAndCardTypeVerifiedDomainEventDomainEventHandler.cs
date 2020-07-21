using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyShop.Orders.Application.DomainEventHandlers.BuyerAndPaymentMethodVerified
{
    public class UpdatePaymentMethodAndCardTypeVerifiedDomainEventDomainEventHandler : INotificationHandler<VerifyOrAddCardTypeDomainEvent>
    {
        private readonly ILogger<UpdatePaymentMethodAndCardTypeVerifiedDomainEventDomainEventHandler> _logger;

        public UpdatePaymentMethodAndCardTypeVerifiedDomainEventDomainEventHandler(ILogger<UpdatePaymentMethodAndCardTypeVerifiedDomainEventDomainEventHandler> logger)
        {
            _logger = logger;
        }
        public async Task Handle(VerifyOrAddCardTypeDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
