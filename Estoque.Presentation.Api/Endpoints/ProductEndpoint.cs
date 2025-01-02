using Estoque.Application.Requests.Products;
using Estoque.Domain.Interfaces;
using Estoque.Presentation.Api.ViewModels;
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
                return Results.Ok(ApiResult.SuccessResult());
            })
                .Produces<ApiResult>(StatusCodes.Status200OK)
                .Produces<ApiResult>(StatusCodes.Status400BadRequest);

            group.MapPut("/{id:long}", (IMediator mediator, IProductRepository repository, long id, [FromBody] UpdateProductRequest request) =>
            {
                var entity = repository.GetById(id);
                if (entity is null)
                    return Results.NotFound();

                mediator.Send(request);
                return Results.Ok(ApiResult.SuccessResult());
            })
                .Produces<ApiResult>(StatusCodes.Status200OK)
                .Produces<ApiResult>(StatusCodes.Status400BadRequest);

            group.MapDelete("/{id:long}", (IMediator mediator, IProductRepository repository, long id) =>
            {
                var entity = repository.GetById(id);
                if (entity is null)
                    return Results.NotFound();

                mediator.Send(new DeleteProductRequest(id));
                return Results.Ok(ApiResult.SuccessResult());
            })
                .Produces<ApiResult>(StatusCodes.Status200OK)
                .Produces<ApiResult>(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status404NotFound);

            group.MapGet("/{id:long}", (IProductRepository repository, long id) =>
            {
                var entity = repository.GetById(id);
                if (entity is null)
                    return Results.NotFound();

                return Results.Ok(ApiResult.SuccessResult(entity));
            })
                .Produces<ApiResult>(StatusCodes.Status200OK)
                .Produces<ApiResult>(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status404NotFound);

            group.MapGet("/", (IProductRepository repository, int page, int limit) =>
                 Results.Ok(ApiResult.SuccessResult(repository.GetAllPaginated(page, limit))))
                .Produces<ApiResult>(StatusCodes.Status200OK)
                .Produces<ApiResult>(StatusCodes.Status400BadRequest);

        }
    }
}
