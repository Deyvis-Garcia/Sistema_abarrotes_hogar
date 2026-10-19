using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AbarrotesHogar.Models;

namespace AbarrotesHogar.Data.Configurations;
public class VentasConfiration : IEntityTypeConfiguration<Ventas>
{
    public void Configure(EntityTypeBuilder<Ventas> builder)
    {
        builder.HasKey(v => v.Id_venta);
        builder.Property( v => v.Total).HasColumnType("decimal(10,2)");
        builder.Property( v => v.Observaciones).HasColumnType("varchar(200)");
        builder.HasOne<Usuarios>().WithMany().HasForeignKey(v => v.Id_usuario).OnDelete(DeleteBehavior.Restrict);
    }
}