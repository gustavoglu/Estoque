using Estoque.Application.Requests.ProductTypes;
using FluentValidation;

namespace Estoque.Application.Validations.ProductTypes
{
    public abstract class ProductTypeRequestValidation<T> : AbstractValidator<T> where T : ProductTypeRequest
    {
        public ProductTypeRequestValidation()
        {
            DescriptionValidate();
        }

        protected void DescriptionValidate() => RuleFor(x => x.Description)
                                                    .MaximumLength(150)
                                                    .NotNull()
                                                    .NotEmpty();
    }
}
