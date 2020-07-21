using MyShop.EventBus.Integration;

namespace MyShop.Payment.IntegrationEvents.Events
{
    public class OrderPaymentSucceededIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; }

        public OrderPaymentSucceededIntegrationEvent(int orderId) => OrderId = orderId;
    }
}