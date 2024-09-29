using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Practico2.Migrations
{
    public partial class Iniciar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Tabla de Roles
            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            // Tabla de Proyectos
            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    HorasTrabajadas = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    HorasTotales = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.Id);
                });

            // Tabla de Usuarios
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RolId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_RolId",
                        column: x => x.RolId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Tabla de Herramientas
            migrationBuilder.CreateTable(
                name: "Herramientas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Herramientas", x => x.Id);
                });

            // Tabla de Tareas
            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Horas = table.Column<int>(type: "int", nullable: false),
                    Area = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ProyectoId = table.Column<int>(type: "int", nullable: false),
                    EmpleadoId = table.Column<int>(type: "int", nullable: false),
                    SetHerramientas = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tareas_Proyectos_ProyectoId",
                        column: x => x.ProyectoId,
                        principalTable: "Proyectos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tareas_Usuarios_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            // Índices para claves foráneas
            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_RolId",
                table: "Usuarios",
                column: "RolId");

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_ProyectoId",
                table: "Tareas",
                column: "ProyectoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_EmpleadoId",
                table: "Tareas",
                column: "EmpleadoId");

            // Insertar datos iniciales en Roles
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 1, "Administrador" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 2, "Empleado" });

            // Insertar datos iniciales en Usuarios
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Nombre", "Apellido", "Email", "Password", "RolId" },
                values: new object[] { 1, "Juan", "Pérez", "juan.perez@example.com", "contraseña123", 1 });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Nombre", "Apellido", "Email", "Password", "RolId" },
                values: new object[] { 2, "Ana", "García", "ana.garcia@example.com", "contraseña456", 2 });

            // Insertar datos iniciales en Herramientas
            migrationBuilder.InsertData(
                table: "Herramientas",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 1, "Destornillador" });

            migrationBuilder.InsertData(
                table: "Herramientas",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 2, "Martillo" });


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Tareas");
            migrationBuilder.DropTable(name: "Herramientas");
            migrationBuilder.DropTable(name: "Usuarios");
            migrationBuilder.DropTable(name: "Proyectos");
            migrationBuilder.DropTable(name: "Roles");
        }
    }
}
