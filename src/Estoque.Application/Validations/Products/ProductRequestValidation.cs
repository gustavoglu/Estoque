using Estoque.Application.Requests.Products;
using Estoque.Domain.Interfaces;
using FluentValidation;

namespace Estoque.Application.Validations.Products
{
    public class ProductRequestValidation<T> : AbstractValidator<T> where T : ProductRequest
    {
        protected IProductTypeRepository ProductTypeRepository { get; }

        public ProductRequestValidation(IProductTypeRepository productTypeRepository)
        {
            ProductTypeRepository = productTypeRepository;
            DescriptionValidate();
            PriceValidate();
            ProductTypeIdValidate();
            ProductTypeExistValidate();

        }

        protected void DescriptionValidate() => RuleFor(x => x.Description)
                                                        .MaximumLength(150)
                                                        .NotNull()
                                                        .NotEmpty();

        protected void PriceValidate() => RuleFor(x => x.Price)
                                                    .NotNull();


        protected void ProductTypeIdValidate() => RuleFor(x => x.ProductTypeId)
                                                   .NotNull()
                                                    .NotEmpty();

        protected void ProductTypeExistValidate() => When(x => x.ProductTypeId.HasValue && 
                                                                x.ProductTypeId != 0,
                                                         () => RuleFor(p => p.ProductTypeId)
                                                                    .Must(ProductTypeExists)
                                                                    .WithMessage("ProductType not found"));


        protected bool ProductTypeExists(long? productTypeId)
            => ProductTypeRepository.GetById(productTypeId!.Value) != null;
    }
}
