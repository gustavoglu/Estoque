using MediatR;

namespace Estoque.Application.Requests.InventoryMovimentations
{
    public class InventoryMovimentationRequest : IRequest
    {
        public long ProductId { get; set; }
        public double Quantity { get; set; }
        public bool Inc { get; set; }
    }
}
