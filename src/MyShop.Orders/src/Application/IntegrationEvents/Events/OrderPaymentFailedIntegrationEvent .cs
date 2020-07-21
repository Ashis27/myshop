using MyShop.EventBus.Integration;

namespace MyShop.Orders.IntegrationEvents.Events
{

    public class OrderPaymentFailedIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; }

        public OrderPaymentFailedIntegrationEvent(int orderId) => OrderId = orderId;
    }
}