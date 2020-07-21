using MediatR;
using MyShop.Consumer.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Consumer.Application.QueryAndHandlers
{
    public class GetConsumerQuery : IRequest<UserDto>
    {
        public Guid Id { get; set; }
        public GetConsumerQuery(Guid id)
        {
            Id = id;
        }
    }
}
