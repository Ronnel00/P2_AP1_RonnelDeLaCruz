using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace P2_AP1_RonnelDeLaCruz.Migrations
{
    /// <inheritdoc />
    public partial class agregandoModelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cantidad",
                table: "Registros",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Cliente",
                table: "Registros",
                type: "TEXT",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Registros",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Registros",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Componente",
                columns: table => new
                {
                    ComponenteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Precio = table.Column<decimal>(type: "TEXT", nullable: false),
                    Existencia = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componente", x => x.ComponenteId);
                });

            migrationBuilder.CreateTable(
                name: "PedidosDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    ComponenteId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidosDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_PedidosDetalle_Componente_ComponenteId",
                        column: x => x.ComponenteId,
                        principalTable: "Componente",
                        principalColumn: "ComponenteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidosDetalle_Registros_Id",
                        column: x => x.Id,
                        principalTable: "Registros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Componente",
                columns: new[] { "ComponenteId", "Descripcion", "Existencia", "Precio" },
                values: new object[,]
                {
                    { 1, "Memoria 4GB", 1, 1580m },
                    { 2, "Disco SSD 120MB", 8, 4200m },
                    { 3, "Tarjeta de Video", 4, 10000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidosDetalle_ComponenteId",
                table: "PedidosDetalle",
                column: "ComponenteId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidosDetalle_Id",
                table: "PedidosDetalle",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PedidosDetalle");

            migrationBuilder.DropTable(
                name: "Componente");

            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "Registros");

            migrationBuilder.DropColumn(
                name: "Cliente",
                table: "Registros");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Registros");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Registros");
        }
    }
}
