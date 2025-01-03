using Estoque.Application.Requests.InventoryMovimentations;
using Estoque.Domain.Interfaces;
using Estoque.Domain.Notifications;
using Estoque.Presentation.Api.Helpers;
using Estoque.Presentation.Api.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Presentation.Api.Endpoints
{
    public static class InventoryMovimentationEndpoint
    {
        public static void MapInventoryMovimentationEndpoints(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("api/inventory/movimentation").WithOpenApi();

            group.MapPost("/", (IMediator mediator,
                                INotificationHandler<DomainNotification> notifications,
                                IInventoryMovimentationRepository repository,
                                
                                [FromBody] InventoryMovimentationRequest request) =>
            {
                var notificationHandler = (DomainNotificationHandler)notifications;
                mediator.Send(request);
                if(notificationHandler.HasNotification)
                    return EndpointHelper.ResponseDefault(notifications);

                double total = repository.GetTotalByProductId(request.ProductId);
                return EndpointHelper.ResponseDefault(notifications, total);
            }).Produces<ApiResult>(StatusCodes.Status200OK)
              .Produces<ApiResult>(StatusCodes.Status400BadRequest);
        }
    }
}
