using Estoque.Domain.Entities;

namespace Estoque.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        bool ProductTypeLinkedExists(long productTypeId);
    }
}
