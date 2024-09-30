using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable
namespace Practico2.Migrations
{
    public partial class BD_Mejorada_VT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Insertar datos iniciales en Usuarios
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Nombre", "Apellido", "Email", "Password", "RolId" },
                values: new object[] { 1, "Juan", "Perez", "juan@juan.cl", "1234", 1 });
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Nombre", "Apellido", "Email", "Password", "RolId" },
                values: new object[] { 2, "Pedro", "Perez", "pedro@pedro.cl", "1234", 2 });
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Eliminar datos insertados en Usuarios
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}