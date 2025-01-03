namespace Estoque.Domain.Entities
{
    public class InventoryMovimentation
    {
        public InventoryMovimentation(long id, DateTime createAt, double quantity, long productId, bool inc)
        {
            Id = id;
            CreateAt = createAt;
            Quantity = quantity;
            ProductId = productId;
            Inc = inc;
        }

        public long Id { get; private set; }
        public DateTime CreateAt { get; set; }
        public long ProductId { get; private set; }
        public double Quantity { get; private set; }
        public bool Inc { get; private set; }

        //ef
        public Product Product { get; set; }
    }
}
