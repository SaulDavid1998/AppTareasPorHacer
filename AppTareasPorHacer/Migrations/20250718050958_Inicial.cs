using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppTareasPorHacer.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    CategoriaId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CategoriaNombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    EstadoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EstadoNombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "Tarea",
                columns: table => new
                {
                    TareaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaTarea = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoriaFK = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EstadoFK = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarea", x => x.TareaId);
                    table.ForeignKey(
                        name: "FK_Tarea_Categoria_CategoriaFK",
                        column: x => x.CategoriaFK,
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarea_Estado_EstadoFK",
                        column: x => x.EstadoFK,
                        principalTable: "Estado",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "CategoriaId", "CategoriaNombre" },
                values: new object[,]
                {
                    { "estudio", "Estudio" },
                    { "hogar", "Hogar" },
                    { "ocio", "Ocio" },
                    { "trabajo", "Trabajo" }
                });

            migrationBuilder.InsertData(
                table: "Estado",
                columns: new[] { "EstadoId", "EstadoNombre" },
                values: new object[,]
                {
                    { "completada", "Completada" },
                    { "pendiente", "Pendiente" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_CategoriaFK",
                table: "Tarea",
                column: "CategoriaFK");

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_EstadoFK",
                table: "Tarea",
                column: "EstadoFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarea");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Estado");
        }
    }
}
