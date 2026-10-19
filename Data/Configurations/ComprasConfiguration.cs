using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AbarrotesHogar.Models;

namespace AbarrotesHogar.Data.Configurations;
public class ComprasConfiguration : IEntityTypeConfiguration<Compras>
{
    public void Configure(EntityTypeBuilder<Compras> builder)
    {
        builder.HasKey(c => c.Id_compra);
        builder.Property(c => c.Observaciones).HasColumnType("varchar(200)");
        builder.Property(c => c.Total).IsRequired().HasColumnType("decimal(10,2)");
        builder.HasOne<Usuarios>().WithMany().HasForeignKey(c => c.Id_usuario).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne<Proveedores>().WithMany().HasForeignKey(c => c.Id_proveedor).OnDelete(DeleteBehavior.Restrict);
    }
}