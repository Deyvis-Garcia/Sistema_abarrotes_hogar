using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AbarrotesHogar.Models;

namespace AbarrotesHogar.Data.Configurations;
public class ProductosConfiguration : IEntityTypeConfiguration<Productos>
{
    public void Configure(EntityTypeBuilder<Productos> builder)
    {
        builder.HasKey(p => p.Id_producto);
        builder.Property(p => p.Nombre).IsRequired().HasColumnType("varchar(100)");
        builder.Property(p => p.Descripcion).IsRequired().HasColumnType("varchar(200)");
        builder.Property( p => p.precio_venta).IsRequired().HasColumnType("decimal(10,2)");
        builder.Property(p => p.Estado).HasDefaultValue(true).IsRequired();
    }
}