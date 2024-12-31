namespace Estoque.Application.Requests.Products
{
    public class InsertProductRequest : ProductRequest
    {
        public InsertProductRequest(long? productTypeId, string? description, decimal? price) : base(productTypeId, description, price)
        {
        }
    }
}
