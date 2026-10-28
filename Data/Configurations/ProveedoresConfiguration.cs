using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AbarrotesHogar.Models;

namespace AbarrotesHogar.Data.Configurations;
public class ProveedoresConfiguration : IEntityTypeConfiguration<Proveedores>
{
    public void Configure(EntityTypeBuilder<Proveedores> builder)
    {
        builder.HasKey( p => p.Id_proveedor);
        builder.Property(p => p.Id_proveedor).UseIdentityColumn(seed: 1, increment: 1);
        builder.Property( p => p.Nombre).IsRequired().HasColumnType("varchar(100)");
        builder.Property( p => p.Ruc).IsRequired().HasColumnType("varchar(20)");
        builder.Property( p => p.Telefono).IsRequired().HasColumnType("varchar(20)");
        builder.Property( p => p.Direccion).IsRequired().HasColumnType("varchar(150)");
        builder.Property( p => p.Correo).IsRequired().HasColumnType("varchar(100)");

        //CONFIGURACION PARA CAMPOS UNICOS
        builder.HasIndex(p => p.Nombre).IsUnique();
        builder.HasIndex(p => p.Ruc).IsUnique();
        builder.HasIndex(p => p.Telefono).IsUnique();
        builder.HasIndex(p => p.Correo).IsUnique();
    }
}
