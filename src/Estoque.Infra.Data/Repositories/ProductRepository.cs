using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces;

namespace Estoque.Infra.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(SQLContext sqlContext) : base(sqlContext)
        {
        }
    }
}
