using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AbarrotesHogar.Models;

namespace AbarrotesHogar.Data.Configurations;
public class UsuariosConfigarition : IEntityTypeConfiguration<Usuarios>
{
    public void Configure(EntityTypeBuilder<Usuarios> builder)
    {
        builder.HasKey(u => u.Id_usuario);
        builder.Property(u => u.Id_usuario).UseIdentityColumn(seed: 1, increment: 1);
        builder.Property( u => u.Nombre).IsRequired().HasColumnType("varchar(100)");
        builder.Property( u => u.Apellido).IsRequired().HasColumnType("varchar(100)");
        builder.Property( u => u.Usuario).IsRequired().HasColumnType("varchar(50)");
        builder.Property( u => u.Contraseña).IsRequired().HasColumnType("varchar(255)");
        builder.Property( u => u.rol).IsRequired().HasColumnType("varchar(30)");
        builder.Property( u => u.Estado).HasDefaultValue(true).IsRequired();

        //CONFIGURACIONES PARA CAMPOS UNICOS
        builder.HasIndex(u => u.Nombre).IsUnique();
        builder.HasIndex(u => u.Usuario).IsUnique();
        builder.HasIndex(u => u.Contraseña).IsUnique();
    }
}