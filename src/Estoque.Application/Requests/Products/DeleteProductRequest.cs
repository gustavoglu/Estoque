using MediatR;

namespace Estoque.Application.Requests.Products
{
    public class DeleteProductRequest : IRequest
    {
        public long? Id { get; set; }

        public DeleteProductRequest(long? id)
        {
            Id = id;
        }
    }
}
