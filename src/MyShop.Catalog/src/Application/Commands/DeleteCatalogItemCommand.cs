using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Catalog.Application.Commands
{
    public class DeleteCatalogItemCommand:IRequest<bool>
    {
        public int Id { get; private set; }

        public DeleteCatalogItemCommand(int id)
        {
            Id = id;
        }
    }
}
