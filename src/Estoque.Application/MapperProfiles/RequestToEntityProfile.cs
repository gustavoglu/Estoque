using AutoMapper;
using Estoque.Application.Requests.Products;
using Estoque.Application.Requests.ProductTypes;
using Estoque.Domain.Entities;

namespace Estoque.Application.MapperProfiles
{
    public class RequestToEntityProfile : Profile
    {
        public RequestToEntityProfile()
        {
            CreateMap<InsertProductRequest, Product>().ReverseMap();
            CreateMap<UpdateProductRequest, Product>().ReverseMap();

            CreateMap<InsertProductTypeRequest, ProductType>().ReverseMap();
            CreateMap<UpdateProductTypeRequest, ProductType>().ReverseMap();
        }
    }
}
