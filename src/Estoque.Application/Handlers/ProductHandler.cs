using AutoMapper;
using Estoque.Application.Requests.Products;
using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces;
using MediatR;

namespace Estoque.Application.Handlers
{
    public class ProductHandler(IUnitOfWork uow, 
                                IProductRepository repository,
                                IMapper mapper) : IRequestHandler<InsertProductRequest>,
                                                        IRequestHandler<UpdateProductRequest>,
                                                        IRequestHandler<DeleteProductRequest>
    {
        public Task Handle(InsertProductRequest request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<Product>(request);
            repository.Insert(entity);
            uow.SaveChanges();
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
