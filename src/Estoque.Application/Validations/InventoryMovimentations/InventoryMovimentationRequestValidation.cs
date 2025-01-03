using Estoque.Application.Requests.InventoryMovimentations;
using Estoque.Domain.Interfaces;
using FluentValidation;

namespace Estoque.Application.Validations.InventoryMovimentations
{
    public class InventoryMovimentationRequestValidation : AbstractValidator<InventoryMovimentationRequest>
    {
        private readonly IProductRepository _productRepository;
        private readonly IInventoryMovimentationRepository _inventoryMovimentationRepository;

        public InventoryMovimentationRequestValidation(IProductRepository productRepository,
                                                            IInventoryMovimentationRepository inventoryMovimentationRepository)
        {
            _productRepository = productRepository;
            _inventoryMovimentationRepository = inventoryMovimentationRepository;

            ProductIdValidate();
            QuantityValidate();
        
        }

        protected bool ProductExistsValidate(InventoryMovimentationRequest request)
        {
            return _productRepository.GetById(request.ProductId) != null;
        }


        protected void ProductIdValidate()
        {
            RuleFor(x => x.ProductId).NotNull().NotEmpty();

            When(x => x.ProductId > 0, () => RuleFor(request => request)
                                                     .Must(ProductExistsValidate)
                                                     .WithMessage("Product not found"));
        }

        protected void QuantityValidate()
        {
            RuleFor(x => x.Quantity).GreaterThan(0);

            When(x => x.Quantity > 0 && !x.Inc, () => RuleFor(request => request)
                                                        .Must(QuantityExistsValidate)
                                                        .WithMessage("Quantity is greater than the quantity in inventory"));
        }

        protected bool QuantityExistsValidate(InventoryMovimentationRequest request)
        {
            var qtInInventory = _inventoryMovimentationRepository.GetTotalByProductId(request.ProductId);

            return request.Quantity <= qtInInventory;


        }
    }
}
