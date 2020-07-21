using Microsoft.EntityFrameworkCore;
using MyShop.CommonUtility.SeedWork;
using MyShop.Orders.Application.Domain;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Orders.Infrastructure.Repositories
{
    public class BuyerRepository : IBuyerRepository
    {
        private readonly OrderingContext _context;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public BuyerRepository(OrderingContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Buyer Add(Buyer buyer)
        {
            return _context.Buyers
                .Add(buyer)
                .Entity;
        }

        public Buyer Update(Buyer buyer)
        {
            return _context.Buyers
                    .Update(buyer)
                    .Entity;
        }

        public async Task<Buyer> FindAsync(string identity)
        {
            var buyer = await _context.Buyers
                .Include(b => b.PaymentMethods)
                .Where(b => b.UserId == identity)
                .SingleOrDefaultAsync();

            return buyer;
        }

        public async Task<Buyer> FindByIdAsync(string id)
        {
            var buyer = await _context.Buyers
                .Include(b => b.PaymentMethods)
                .Where(b => b.Id == int.Parse(id))
                .SingleOrDefaultAsync();

            return buyer;
        }
    }
}
