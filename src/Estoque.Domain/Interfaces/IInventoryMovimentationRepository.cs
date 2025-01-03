using Estoque.Domain.Entities;

namespace Estoque.Domain.Interfaces
{
    public interface IInventoryMovimentationRepository
    {
        void Insert(InventoryMovimentation movimentation);

        double GetTotalByProductId(long productId);
    }
}
