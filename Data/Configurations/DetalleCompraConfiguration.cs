using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AbarrotesHogar.Models;

namespace AbarrotesHogar.Data.Configurations;
public class DetalleCompraConfiguration : IEntityTypeConfiguration<DetalleCompras>
{
    public void Configure(EntityTypeBuilder<DetalleCompras> builder)
    {
        builder.HasKey(d => d.Id_detalle_compra);
        builder.Property(d => d.Precio_unitario).IsRequired().HasColumnType("decimal(10,2)");
        builder.Property(d => d.Subtotal).IsRequired().HasColumnType("decimal(10,2)");
        builder.HasOne<Compras>().WithMany().HasForeignKey(d => d.Id_compra).OnDelete(DeleteBehavior.Cascade);
        builder.HasOne<Productos>().WithMany().HasForeignKey(d => d.Id_producto).OnDelete(DeleteBehavior.Restrict);
    }
}