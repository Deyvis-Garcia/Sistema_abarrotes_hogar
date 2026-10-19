using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AbarrotesHogar.Models;

namespace AbarrotesHogar.Data.Configurations;
public class UsuariosConfigarition : IEntityTypeConfiguration<Usuarios>
{
    public void Configure(EntityTypeBuilder<Usuarios> builder)
    {
        builder.HasKey(u => u.Id_usuario);
        builder.Property( u => u.Nombre).HasColumnType("varchar(100)");
        builder.Property( u => u.Apellido).HasColumnType("varchar(100)");
        builder.Property( u => u.Usuario).HasColumnType("varchar(50)");
        builder.Property( u => u.Contraseña).HasColumnType("varchar(255)");
        builder.Property( u => u.rol).HasColumnType("varchar(30)");
        builder.Property( u => u.Estado).HasDefaultValue(true).IsRequired();
    }
}