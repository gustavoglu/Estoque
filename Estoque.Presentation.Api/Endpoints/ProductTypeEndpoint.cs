using Estoque.Application.Requests.ProductTypes;
using Estoque.Domain.Interfaces;
using Estoque.Presentation.Api.ViewModels;
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
                return Results.Ok(ApiResult.SuccessResult());
            })
           .Produces<ApiResult>(StatusCodes.Status200OK)
           .Produces<ApiResult>(StatusCodes.Status400BadRequest);

            group.MapPut("/{id:long}", (IMediator mediator, IProductTypeRepository repository, long id, [FromBody] UpdateProductTypeRequest request) =>
            {
                var entity = repository.GetById(id);
                if (entity is null)
                    return Results.NotFound();

                mediator.Send(request);
                return Results.Ok(ApiResult.SuccessResult());
            })
                .Produces<ApiResult>(StatusCodes.Status200OK)
                .Produces<ApiResult>(StatusCodes.Status400BadRequest);

            group.MapDelete("/{id:long}", (IMediator mediator, IProductTypeRepository repository, long id) =>
            {
                var entity = repository.GetById(id);
                if (entity is null)
                    return Results.NotFound();

                mediator.Send(new DeleteProductTypeRequest(id));
                return Results.Ok(ApiResult.SuccessResult());
            })
                .Produces<ApiResult>(StatusCodes.Status200OK)
                .Produces<ApiResult>(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status404NotFound);

            group.MapGet("/{id:long}", (IProductTypeRepository repository, long id) =>
            {
                var entity = repository.GetById(id);
                if (entity is null)
                    return Results.NotFound();

                return Results.Ok(ApiResult.SuccessResult(entity));
            })
                .Produces<ApiResult>(StatusCodes.Status200OK)
                .Produces<ApiResult>(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status404NotFound);

            group.MapGet("/", (IProductTypeRepository repository, int page, int limit) =>
                 Results.Ok(ApiResult.SuccessResult(repository.GetAllPaginated(page, limit))))
                .Produces<ApiResult>(StatusCodes.Status200OK)
                .Produces<ApiResult>(StatusCodes.Status400BadRequest);

        }
    }
}
