using MediatR;
using MyShop.Identity.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Identity.Application.DomainEventHandlers.UserCreated
{
    public class UserCreatedDomainEvent : INotification
    {
        public Guid UserId { get; set; }
        public User User { get; private set; }
        public UserCreatedDomainEvent(Guid userId, User user)
        {
            UserId = userId;
            User = user;
        }
    }
}
