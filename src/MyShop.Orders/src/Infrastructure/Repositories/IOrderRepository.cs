using MyShop.CommonUtility.SeedWork;
using MyShop.Orders.Application.Domain;
using System.Threading.Tasks;

namespace MyShop.Orders.Infrastructure.Repositories
{
    //This is just the RepositoryContracts or Interface defined at the Domain Layer
    //as requisite for the Order Aggregate

    public interface IOrderRepository : IRepository
    {
        Order Add(Order order);
        
        void Update(Order order);

        Task<Order> GetAsync(int orderId);
    }
}
