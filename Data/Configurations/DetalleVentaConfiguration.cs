using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AbarrotesHogar.Models;

namespace AbarrotesHogar.Data.Configurations;
public class DetalleVentaConfiguration : IEntityTypeConfiguration<DetalleVenta>
{
    public void Configure(EntityTypeBuilder<DetalleVenta> builder)
    {
        builder.HasKey(v => v.Id_detalle_venta);
        builder.Property(v => v.Precio_unitario).IsRequired().HasColumnType("decimal(10,2)");
        builder.Property(v => v.Subtotal).IsRequired().HasColumnType("decimal(10,2)");
        builder.HasOne<Ventas>().WithMany().HasForeignKey(v => v.Id_venta).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne<Productos>().WithMany().HasForeignKey(v => v.Id_producto).OnDelete(DeleteBehavior.Restrict);
    }
}