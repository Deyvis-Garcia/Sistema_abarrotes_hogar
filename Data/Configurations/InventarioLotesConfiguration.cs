using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AbarrotesHogar.Models;

namespace AbarrotesHogar.Data.Configurations;
public class InventarioLotesConfiguration : IEntityTypeConfiguration<InventarioLotes>
{
    public void Configure(EntityTypeBuilder<InventarioLotes> builder)
    {
        builder.HasKey(l => l.Id_lote);
        builder.Property(l => l.Cantidad_lote).IsRequired().HasColumnType("decimal(10,2)");
        builder.Property(l => l.Costo_unitario).IsRequired().HasColumnType("decimal(10,2)");
        builder.Property(l => l.Estado).HasDefaultValue(true).IsRequired();
        builder.HasOne<Productos>().WithMany().HasForeignKey(l => l.Id_producto).OnDelete(DeleteBehavior.Restrict);
    }
}