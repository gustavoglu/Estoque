namespace Estoque.Application.Requests.Products
{
    public class InsertProductRequest : ProductRequest
    {
        public double InventoryQuantity { get; set; }
        public InsertProductRequest(long? productTypeId, string? description, decimal? price) : base(productTypeId, description, price)
        {
        }
    }
}
