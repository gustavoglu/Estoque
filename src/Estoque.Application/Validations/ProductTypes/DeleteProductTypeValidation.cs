using Estoque.Application.Requests.ProductTypes;
using FluentValidation;

namespace Estoque.Application.Validations.ProductTypes
{
    public class DeleteProductTypeValidation : AbstractValidator<DeleteProductTypeRequest>
    {
        public DeleteProductTypeValidation()
        {
            IdValidate();
        }

        protected void IdValidate() => RuleFor(x => x.Id)
                                           .NotNull()
                                           .NotEmpty();
    }
}
