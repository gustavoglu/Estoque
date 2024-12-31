namespace Estoque.Domain.Entities
{
    public class ProductType(long id, 
                                DateTime createAt, 
                                bool isDeleted, 
                                string description) : Entity(id, createAt, isDeleted)
    {
        public string Description { get; private set; } = description;

        //EF
        public List<Product> Products { get; set; }
    }
}
