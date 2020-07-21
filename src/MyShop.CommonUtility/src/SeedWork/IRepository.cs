namespace MyShop.CommonUtility.SeedWork
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
