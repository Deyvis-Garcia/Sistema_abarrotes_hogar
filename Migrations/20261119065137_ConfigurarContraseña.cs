using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AbarrotesHogar.Migrations
{
    /// <inheritdoc />
    public partial class ConfigurarContraseña : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Usuarios_Contraseña",
                table: "Usuarios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Contraseña",
                table: "Usuarios",
                column: "Contraseña",
                unique: true);
        }
    }
}
