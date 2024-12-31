namespace Estoque.Application.Requests.ProductTypes
{
    public class UpdateProductTypeRequest : ProductTypeRequest
    {
        public long Id { get; set; }
        public UpdateProductTypeRequest(long id, string description) : base(description)
        {
            Id = id;
        }
    }
}
