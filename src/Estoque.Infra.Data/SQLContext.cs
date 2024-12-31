using Estoque.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Estoque.Infra.Data
{
    public class SQLContext : DbContext
    {
        public SQLContext(DbContextOptions<SQLContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }
         
        public override int SaveChanges()
        {
            SetInsertEntityProperties();
            SetUpdateEntityProperties();
            SetDeleteEntityProperties();
           
            return base.SaveChanges();
        }

        private void SetDeleteEntityProperties()
        {
            var deletes = this.ChangeTracker.Entries()
                                                .Where(entry => entry.Entity is Entity &&
                                                                  entry.State == EntityState.Deleted);



            foreach (var entry in deletes)
            {
                var entity = entry.Entity as Entity;
                entity!.UpdateAt = DateTime.UtcNow;
                entity!.IsDeleted = true;
            }
        }

        private void SetInsertEntityProperties()
        {
            var inserts = this.ChangeTracker.Entries()
                                                .Where(entry => entry.Entity is Entity && 
                                                                 entry.State == EntityState.Added);



            foreach (var entry in inserts)
            {
                var entity = entry.Entity as Entity;
                entity!.CreateAt = DateTime.UtcNow;
            }
        }

        private void SetUpdateEntityProperties()
        {
            var updates = this.ChangeTracker.Entries()
                                               .Where(entry => entry.Entity is Entity &&
                                                                   entry.State == EntityState.Modified);

            foreach (var entry in updates)
            {
                var entity = entry.Entity as Entity;
                entity!.UpdateAt = DateTime.UtcNow;
            }
        }
    }
}
