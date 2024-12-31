using Estoque.Application.Requests.Products;
using FluentValidation;

namespace Estoque.Application.Validations.Products
{
    public class ProductRequestValidation<T> : AbstractValidator<T> where T : ProductRequest
    {
        public ProductRequestValidation()
        {
            DescriptionValidate();
            PriceValidate();
            ProductTypeIdValidate();
        }

        protected void DescriptionValidate() => RuleFor(x => x.Description)
                                                        .MaximumLength(150)
                                                        .NotNull()
                                                        .Empty();

        protected void PriceValidate() => RuleFor(x => x.Price)
                                                    .NotNull();


        protected void ProductTypeIdValidate() => RuleFor(x => x.ProductTypeId)
                                                   .NotNull()
                                                    .NotEmpty();
    }
}
