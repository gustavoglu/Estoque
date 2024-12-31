namespace Estoque.Domain.Entities
{
    public class Entity
    {
        public Entity(long id, DateTime createAt, bool isDeleted)
        {
            Id = id;
            CreateAt = createAt;
            IsDeleted = isDeleted;
        }

        public long Id { get; private set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
