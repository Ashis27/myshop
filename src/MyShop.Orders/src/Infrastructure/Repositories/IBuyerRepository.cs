using MyShop.CommonUtility.SeedWork;
using MyShop.Orders.Application.Domain;
using System.Threading.Tasks;

namespace MyShop.Orders.Infrastructure.Repositories
{
    //This is just the RepositoryContracts or Interface defined at the Domain Layer
    //as requisite for the Buyer Aggregate

    public interface IBuyerRepository : IRepository
    {
        Buyer Add(Buyer buyer);
        Buyer Update(Buyer buyer);
        Task<Buyer> FindAsync(string BuyerIdentityGuid);
        Task<Buyer> FindByIdAsync(string id);
    }
}
