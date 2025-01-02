using Estoque.Application.Requests.Products;
using Estoque.Domain.Interfaces;

namespace Estoque.Application.Validations.Products
{
    public class InsertProductRequestValidation : ProductRequestValidation<InsertProductRequest>
    {
        public InsertProductRequestValidation(IProductTypeRepository productTypeRepository) : base(productTypeRepository)
        {
            
        }
    }
}
