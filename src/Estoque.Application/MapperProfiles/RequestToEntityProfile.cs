using AutoMapper;
using Estoque.Application.Requests.InventoryMovimentations;
using Estoque.Application.Requests.Products;
using Estoque.Application.Requests.ProductTypes;
using Estoque.Domain.Entities;

namespace Estoque.Application.MapperProfiles
{
    public class RequestToEntityProfile : Profile
    {
        public RequestToEntityProfile()
        {
            CreateMap<InsertProductRequest, Product>()
                .ConstructUsing((_) =>
                                     new Product(0,
                                             DateTime.UtcNow,
                                             false,
                                             _.Description!,
                                             _.Price!.Value,
                                             _.ProductTypeId!.Value)
                                    );

            CreateMap<UpdateProductRequest, Product>()
                .ConstructUsing(_ => new Product(_.Id,
                                                    default,
                                                    default,
                                                    _.Description!,
                                                    _.Price!.Value,
                                                    _.ProductTypeId!.Value));

            CreateMap<InsertProductTypeRequest, ProductType>()
                .ConstructUsing(_ => new ProductType(0,
                                                    default,
                                                    default,
                                                    _.Description!));

            CreateMap<UpdateProductTypeRequest, ProductType>()
                .ConstructUsing(_ => new ProductType(_.Id,
                                                    default,
                                                    default,
                                                    _.Description!));

            CreateMap<InventoryMovimentationRequest, InventoryMovimentation>()
                .ConstructUsing(_ => new InventoryMovimentation(default,
                                               default,
                                               _.Quantity,
                                               _.ProductId,
                                               _.Inc));
        }
    }
}
