namespace Estoque.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        bool SaveChanges();
    }
}
