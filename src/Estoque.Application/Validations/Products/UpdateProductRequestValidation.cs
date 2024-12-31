using Estoque.Application.Requests.Products;
using FluentValidation;

namespace Estoque.Application.Validations.Products
{
    public class UpdateProductRequestValidation : ProductRequestValidation<UpdateProductRequest>
    {
        public UpdateProductRequestValidation() : base()
        {
            IdValidate();
        }

        protected void IdValidate() => RuleFor(x => x.Id)
                                            .NotNull()
                                            .NotEmpty();
    }
}
