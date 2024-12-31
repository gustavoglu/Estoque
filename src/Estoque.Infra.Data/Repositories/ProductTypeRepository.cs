using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces;

namespace Estoque.Infra.Data.Repositories
{
    public class ProductTypeRepository : Repository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(SQLContext sqlContext) : base(sqlContext)
        {
        }
    }
}
