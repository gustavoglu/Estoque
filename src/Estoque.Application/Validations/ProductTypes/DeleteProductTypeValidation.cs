using Estoque.Application.Requests.ProductTypes;
using Estoque.Domain.Interfaces;
using FluentValidation;

namespace Estoque.Application.Validations.ProductTypes
{
    public class DeleteProductTypeValidation : AbstractValidator<DeleteProductTypeRequest>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductTypeValidation(IProductRepository productRepository)
        {
            IdValidate();
            ProductLinkedExistsValidate();
            this._productRepository = productRepository;
        }

        protected void IdValidate() => RuleFor(x => x.Id)
                                           .NotNull()
                                           .NotEmpty();


        protected void ProductLinkedExistsValidate()
        {
            When(x => x.Id.HasValue, 
                () => RuleFor(x => x.Id)
            .Must((long? id) => !_productRepository.ProductTypeLinkedExists(id!.Value))
            .WithMessage("ProductType linked to other Products"));
        }
    }
}
