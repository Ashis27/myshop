using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyShop.CommonUtility.Types
{
    public abstract class BaseEntity
    {
        public int Id { get; protected set; }
        public Guid UId { get; protected set; }
        public int CreatedBy { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        public DateTime UpdatedDate { get; protected set; }
        public int UpdatedBy { get; protected set; }

        private List<INotification> _domainEvents;
        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents?.AsReadOnly();

        public BaseEntity()
        {
            Id = 0;
            UId = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
            CreatedBy = 1;
            UpdatedDate = DateTime.Now;
        }

        public void AddDomainEvent(INotification eventItem)
        {
            _domainEvents = _domainEvents ?? new List<INotification>();
            _domainEvents.Add(eventItem);
        }

        public void RemoveDomainEvent(INotification eventItem)
        {
            _domainEvents?.Remove(eventItem);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }
    }
}