namespace Estoque.Application.Requests.ProductTypes
{
    public class InsertProductTypeRequest : ProductTypeRequest
    {
        public InsertProductTypeRequest(string description) : base(description)
        {
        }
    }
}
