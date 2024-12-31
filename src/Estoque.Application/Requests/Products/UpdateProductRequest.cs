namespace Estoque.Application.Requests.Products
{
    public class UpdateProductRequest : ProductRequest
    {
        public long? Id { get; set; }
        public UpdateProductRequest(long? id, long? productTypeId, string? description, decimal? price) : base(productTypeId, description, price)
        {
            Id = id;
        }
    }
}
