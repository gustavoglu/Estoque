using Estoque.Application.Requests.Products;
using Estoque.Domain.Interfaces;
using FluentValidation;

namespace Estoque.Application.Validations.Products
{
    public class UpdateProductRequestValidation : ProductRequestValidation<UpdateProductRequest>
    {
        public UpdateProductRequestValidation(IProductTypeRepository productTypeRepository) : base(productTypeRepository)
        {
            IdValidate();
        }

        protected void IdValidate() => RuleFor(x => x.Id)
                                            .NotNull()
                                            .NotEmpty();
    }
}
