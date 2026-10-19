using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AbarrotesHogar.Models;

namespace AbarrotesHogar.Data.Configurations;
public class ProveedoresConfiguration : IEntityTypeConfiguration<Proveedores>
{
    public void Configure(EntityTypeBuilder<Proveedores> builder)
    {
        builder.HasKey( p => p.Id_proveedor);
        builder.Property( p => p.Nombre).HasColumnType("varchar(100)");
        builder.Property( p => p.Ruc).HasColumnType("varchar(20)");
        builder.Property( p => p.Telefono).HasColumnType("varchar(20)");
        builder.Property( p => p.Direccion).HasColumnType("varchar(150)");
        builder.Property( p => p.Correo).HasColumnType("varchar(100)");
    }
}