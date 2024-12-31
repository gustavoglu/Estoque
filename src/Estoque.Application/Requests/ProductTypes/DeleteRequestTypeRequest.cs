using MediatR;

namespace Estoque.Application.Requests.ProductTypes
{
    public class DeleteProductTypeRequest : IRequest
    {
        public long? Id { get; set; }

        public DeleteProductTypeRequest(long? id)
        {
            Id = id;
        }
    }
}
