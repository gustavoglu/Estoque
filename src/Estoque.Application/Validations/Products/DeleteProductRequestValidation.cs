using Estoque.Application.Requests.Products;
using FluentValidation;

namespace Estoque.Application.Validations.Products
{
    public class DeleteProductRequestValidation : AbstractValidator<DeleteProductRequest>
    {
        public DeleteProductRequestValidation()
        {
            IdValidate();
        }

        protected void IdValidate() => RuleFor(x => x.Id)
                                           .NotNull()
                                           .NotEmpty();
    }
}
