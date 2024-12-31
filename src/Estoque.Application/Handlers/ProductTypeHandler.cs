using AutoMapper;
using Estoque.Application.Requests.ProductTypes;
using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces;
using MediatR;

namespace Estoque.Application.Handlers
{
    public class ProductTypeHandler(IUnitOfWork uow,
                               IProductTypeRepository repository,
                               IMapper mapper) : IRequestHandler<InsertProductTypeRequest>,
                                                       IRequestHandler<UpdateProductTypeRequest>,
                                                       IRequestHandler<DeleteProductTypeRequest>
    {
        public Task Handle(InsertProductTypeRequest request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<ProductType>(request);
            repository.Insert(entity);
            uow.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Handle(UpdateProductTypeRequest request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<ProductType>(request);
            repository.Update(entity);
            uow.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Handle(DeleteProductTypeRequest request, CancellationToken cancellationToken)
        {
            repository.Delete(request.Id!.Value);
            uow.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
