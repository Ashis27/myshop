using MyShop.CommonUtility.Types;
using MyShop.Orders.Application.DomainEventHandlers.BuyerAndPaymentMethodVerified;
using MyShop.Orders.Application.DomainEventHandlers.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Orders.Application.Domain
{
    public class Buyer : BaseEntity
    {
        private List<PaymentMethod> _paymentMethods;
        
        public string UserId { get; private set; }

        public string Name { get; private set; }

        public IEnumerable<PaymentMethod> PaymentMethods => _paymentMethods.AsReadOnly();

        protected Buyer()
        {
            _paymentMethods = new List<PaymentMethod>();
        }
        public Buyer(string id, string name)
        {
            UserId = !string.IsNullOrWhiteSpace(id) ? id : throw new ArgumentNullException(nameof(id));
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
            _paymentMethods = new List<PaymentMethod>();
        }


        public PaymentMethod VerifyOrAddPaymentMethod(int cardTypeId, string alias, string cardNumber,
            string securityNumber, string cardHolderName, DateTime expiration, int orderId)
        {
            var existingPayment = _paymentMethods
             .SingleOrDefault(p => p.IsEqualTo(cardTypeId, cardNumber, expiration));

            if (existingPayment != null)
            {
                AddDomainEvent(new BuyerAndPaymentMethodVerifiedDomainEvent(this, existingPayment, orderId));

                return existingPayment;
            }

            var payment = new PaymentMethod(cardTypeId, alias, cardNumber, securityNumber, cardHolderName, expiration);

            _paymentMethods.Add(payment);

            AddDomainEvent(new BuyerAndPaymentMethodVerifiedDomainEvent(this, payment, orderId));

            return payment;
        }
    }
}
