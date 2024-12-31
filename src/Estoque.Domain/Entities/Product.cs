namespace Estoque.Domain.Entities
{
    public class Product(long id,
                            DateTime createAt,
                            bool isDeleted,
                            string description,
                            decimal price,
                            long productTypeId) : Entity(id, createAt, isDeleted)
    {
        public string Description { get; private set; } = description;
        public decimal Price { get; private set; } = price;
        public long ProductTypeId { get; private set; } = productTypeId;

        //EF
        public ProductType ProductType { get; set; }
    }
}
