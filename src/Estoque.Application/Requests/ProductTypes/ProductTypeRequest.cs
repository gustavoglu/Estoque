using MediatR;

namespace Estoque.Application.Requests.ProductTypes
{
    public abstract class ProductTypeRequest : IRequest
    {
        public string Description { get; set; }

        public ProductTypeRequest(string description)
        {
            Description = description;
        }
    }






}
