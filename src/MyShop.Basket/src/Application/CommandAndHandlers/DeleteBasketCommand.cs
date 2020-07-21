using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MyShop.Basket.Application.CommandAndHandlers
{
    public class DeleteBasketCommand:IRequest<bool>
    {
        public string Id { get; set; }

        public DeleteBasketCommand(string id)
        {
            Id = id;
        }
    }
}
