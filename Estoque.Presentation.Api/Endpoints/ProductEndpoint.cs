using Estoque.Application.Requests.Products;
using Estoque.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Estoque.Presentation.Api.Endpoints
{
    public static class ProductEndpoint
    {
        public static void MapProductEndpoints(this IEndpointRouteBuilder builder)
        {

            var group = builder.MapGroup("/product").WithOpenApi();


            group.MapPost("/", (IMediator mediator, [FromBody] InsertProductRequest request) =>
            {
                mediator.Send(request);
                return Results.Ok;
            });

            group.MapPut("/{id:long}", (IMediator mediator, IProductRepository repository, long id, [FromBody] UpdateProductRequest request) =>
            {
                var entity = repository.GetById(id);
                if (entity is null)
                    return Results.NotFound;

                mediator.Send(request);
                return Results.Ok;
            });

            group.MapDelete("/{id:long}", (IMediator mediator, IProductRepository repository, long id) =>
            {
                var entity = repository.GetById(id);
                if (entity is null)
                    return Results.NotFound;

                mediator.Send(new DeleteProductRequest(id));
                return Results.Ok;
            });

            group.MapGet("/{id:long}", (IProductRepository repository, long id) =>
            {
                var entity = repository.GetById(id);
                if (entity is null)
                    return Results.NotFound();

                return Results.Ok(entity);
            });

            group.MapGet("/", (IProductRepository repository, int page, int limit) =>
                 Results.Ok(repository.GetAllPaginated(page, limit)));

        }
    }
}
