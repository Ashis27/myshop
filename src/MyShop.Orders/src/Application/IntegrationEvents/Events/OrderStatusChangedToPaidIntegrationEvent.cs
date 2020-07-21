﻿namespace MyShop.Orders.IntegrationEvents.Events
{
    using MyShop.EventBus.Integration;
    using System.Collections.Generic;
    public class OrderStatusChangedToPaidIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; }
        public string OrderStatus { get; }
        public string BuyerName { get; }
        public IEnumerable<OrderStockItem> OrderStockItems { get; }

        public OrderStatusChangedToPaidIntegrationEvent(int orderId,
            string orderStatus,
            string buyerName,
            IEnumerable<OrderStockItem> orderStockItems)
        {
            OrderId = orderId;
            OrderStockItems = orderStockItems;
            OrderStatus = orderStatus;
            BuyerName = buyerName;
        }
    }
}
