using Estoque.Application.Requests.ProductTypes;
using Estoque.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Presentation.Api.Endpoints
{
    public static class ProductTypeEndpoint
    {
        public static void MapProductTypeEndpoints(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("/product-type").WithOpenApi();

            group.MapPost("/", (IMediator mediator, [FromBody] InsertProductTypeRequest request) =>
            {
                mediator.Send(request);
                return Results.Ok;
            });

            group.MapPut("/{id:long}", (IMediator mediator, IProductTypeRepository repository, long id, [FromBody] UpdateProductTypeRequest request) =>
            {
                var entity = repository.GetById(id);
                if (entity is null)
                    return Results.NotFound;

                mediator.Send(request);
                return Results.Ok;
            });

            group.MapDelete("/{id:long}", (IMediator mediator, IProductTypeRepository repository, long id) =>
            {
                var entity = repository.GetById(id);
                if (entity is null)
                    return Results.NotFound;

                mediator.Send(new DeleteProductTypeRequest(id));
                return Results.Ok;
            });

            group.MapGet("/{id:long}", (IProductTypeRepository repository, long id) =>
            {
                var entity = repository.GetById(id);
                if (entity is null)
                    return Results.NotFound();

                return Results.Ok(entity);
            });

            group.MapGet("/", (IProductTypeRepository repository, int page, int limit) =>
                 Results.Ok(repository.GetAllPaginated(page, limit)));

        }
    }
}
