using AutoMapper;
using Estoque.Application.Requests.InventoryMovimentations;
using Estoque.Domain.Entities;
using Estoque.Domain.Interfaces;
using MediatR;

namespace Estoque.Application.Handlers
{
    public class InventoryMovimentationHandler(IInventoryMovimentationRepository repository,
                                                IMapper mapper,
                                                IUnitOfWork uow) : IRequestHandler<InventoryMovimentationRequest>
    {
        public Task Handle(InventoryMovimentationRequest request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<InventoryMovimentation>(request);
            entity.CreateAt = DateTime.Now;
            repository.Insert(entity);
            uow.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
