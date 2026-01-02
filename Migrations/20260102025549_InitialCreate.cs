using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorRegistroUsuarios.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsuariosRegistradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDocumento = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Trabaja = table.Column<bool>(type: "bit", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Permiso = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosRegistradores", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosRegistradores_Correo",
                table: "UsuariosRegistradores",
                column: "Correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosRegistradores_NumeroDocumento",
                table: "UsuariosRegistradores",
                column: "NumeroDocumento",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsuariosRegistradores");
        }
    }
}
