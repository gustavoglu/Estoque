using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Infra.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(SQLContext sqlContext) : base(sqlContext)
        {
        }

        public bool ProductTypeLinkedExists(long productTypeId)
        {
            var count = DbSet
                .IgnoreQueryFilters()
                .LongCount(x => x.ProductTypeId == productTypeId);

            return count > 0;
        }
    }
}
