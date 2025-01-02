using Estoque.Domain.Interfaces;
using Estoque.Domain.Notifications;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Estoque.Infra.Data
{
    public class UnitOfWork(SQLContext context,
                            ILogger<UnitOfWork> logger,
                            IMediator mediator) : IUnitOfWork
    {

        public bool SaveChanges()
        {
            try
            {
                return context.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                string message = $"An error occurred and the database could not be updated, error: {ex.Message}";
                logger.LogError(message, ex);
                mediator.Publish(new DomainNotification(nameof(UnitOfWork), message));
                return false;
            }
        }
    }
}
