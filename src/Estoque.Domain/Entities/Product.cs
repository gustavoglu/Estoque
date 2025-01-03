
namespace Estoque.Domain.Entities
{
    public class Product : Entity
    {
        public Product(long id, DateTime createAt, bool isDeleted, string description,
                        decimal price, long productTypeId) : base(id, createAt, isDeleted)
        {
            Description = description;
            Price = price;
            ProductTypeId = productTypeId;
        }

        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public long ProductTypeId { get; private set; }

        //EF
        public ProductType ProductType { get; set; }
        public List<InventoryMovimentation>? Movimentations { get; set; }
    }
}
