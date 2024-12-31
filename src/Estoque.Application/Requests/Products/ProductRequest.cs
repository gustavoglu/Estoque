using MediatR;

namespace Estoque.Application.Requests.Products
{
    public abstract class ProductRequest : IRequest
    {
        public ProductRequest(long? productTypeId, string? description, decimal? price)
        {
            ProductTypeId = productTypeId;
            Description = description;
            Price = price;
        }

        public long? ProductTypeId { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
    }
}
