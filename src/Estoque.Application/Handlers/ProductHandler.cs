using AutoMapper;
using Estoque.Application.Requests.InventoryMovimentations;
using Estoque.Application.Requests.Products;
using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces;
using Estoque.Domain.Notifications;
using MediatR;

namespace Estoque.Application.Handlers
{
    public class ProductHandler(IUnitOfWork uow,
                                IProductRepository repository,
                                IProductTypeRepository productTypeRepository,
                                IMediator mediator,
                                INotificationHandler<DomainNotification> notifications,
                                IMapper mapper) : IRequestHandler<InsertProductRequest>,
                                                        IRequestHandler<UpdateProductRequest>,
                                                        IRequestHandler<DeleteProductRequest>
    {

        private bool ProductTypeExistsValidate(long productTypeId)
        {
            var productTypeExists = productTypeRepository.GetById(productTypeId) != null;
            if (!productTypeExists)
            {
                mediator.Publish(new DomainNotification(nameof(ProductHandler), "ProductType not found"));
                return false;
            }

            return true;
        }

        public Task Handle(InsertProductRequest request, CancellationToken cancellationToken)
        {
            var notificationHandler = (DomainNotificationHandler)notifications;

            var entity = mapper.Map<Product>(request);
            repository.Insert(entity);
            uow.SaveChanges();

            if (notificationHandler.HasNotification)
                return Task.CompletedTask;

            if (request.InventoryQuantity > 0)
            {
                mediator.Send(new InventoryMovimentationRequest() { ProductId = entity.Id, Inc = true, Quantity = request.InventoryQuantity });
                uow.SaveChanges();
            }
            return Task.CompletedTask;
        }

        public Task Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Product>(request);
            repository.Update(entity);
            uow.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            repository.Delete(request.Id!.Value);
            uow.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
