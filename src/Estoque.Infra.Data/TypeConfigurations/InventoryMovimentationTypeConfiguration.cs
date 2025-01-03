using Estoque.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Estoque.Infra.Data.TypeConfigurations
{
    public class InventoryMovimentationTypeConfiguration : IEntityTypeConfiguration<InventoryMovimentation>
    {
        public void Configure(EntityTypeBuilder<InventoryMovimentation> builder)
        {
            builder.ToTable(nameof(InventoryMovimentation));

            builder.HasKey(x => x.Id);

            builder.Property(x => x.CreateAt)
                .IsRequired();

            builder.Property(x => x.Quantity)
               .IsRequired();

            builder.HasOne(x => x.Product)
                .WithMany(y => y.Movimentations)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
