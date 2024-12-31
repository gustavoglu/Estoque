using Estoque.Application.Requests.ProductTypes;
using FluentValidation;

namespace Estoque.Application.Validations.ProductTypes
{
    public class UpdateProductTypeRequestValidation : ProductTypeRequestValidation<UpdateProductTypeRequest>
    {
        public UpdateProductTypeRequestValidation() : base()
        {
            IdValidate();
        }

        protected void IdValidate() => RuleFor(x => x.Id)
                                        .NotNull()
                                        .NotEmpty();
    }
}
