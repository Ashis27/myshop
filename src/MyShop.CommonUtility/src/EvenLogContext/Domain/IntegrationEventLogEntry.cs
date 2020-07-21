using MyShop.CommonUtility.EvenLogContext.Services;
using MyShop.EventBus.Integration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MyShop.CommonUtility.EvenLogContext.Domain
{
    public class IntegrationEventLogEntry
    {
        public Guid EventId { get; private set; }

        public string EventTypeName { get; private set; }

        [NotMapped]
        public string EventTypeShortName => EventTypeName.Split('.')?.Last();

        public string Content { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public string TransactionId { get; private set; }

        [NotMapped]
        public IntegrationEvent IntegrationEvent { get; private set; }

        public EventStateEnum State { get; set; }

        private IntegrationEventLogEntry() { }

        public IntegrationEventLogEntry(IntegrationEvent @event, Guid transactionId)
        {
            EventId = @event.Id;
            CreatedAt = @event.CreationDate;
            EventTypeName = @event.GetType().FullName;
            Content = JsonConvert.SerializeObject(@event);
            State = EventStateEnum.NotPublished;
            TransactionId = transactionId.ToString();
        }

        public IntegrationEventLogEntry DeserializeJsonContent(List<Type> type)
        {
            IntegrationEvent = JsonConvert.DeserializeObject(Content, type.Find(e=>e.Name == EventTypeShortName)) as IntegrationEvent;
            return this;
        }
    }
}
