using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P2_AP1_RonnelDeLaCruz.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDetalle_Componente_ComponenteId",
                table: "PedidosDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDetalle_Registros_Id",
                table: "PedidosDetalle");

            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidosDetalle",
                table: "PedidosDetalle");

            migrationBuilder.DropIndex(
                name: "IX_PedidosDetalle_Id",
                table: "PedidosDetalle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Componente",
                table: "Componente");

            migrationBuilder.RenameTable(
                name: "PedidosDetalle",
                newName: "PedidosDetalles");

            migrationBuilder.RenameTable(
                name: "Componente",
                newName: "Componentes");

            migrationBuilder.RenameColumn(
                name: "DetalleId",
                table: "PedidosDetalles",
                newName: "PedidoId");

            migrationBuilder.RenameIndex(
                name: "IX_PedidosDetalle_ComponenteId",
                table: "PedidosDetalles",
                newName: "IX_PedidosDetalles_ComponenteId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PedidosDetalles",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "PedidoId",
                table: "PedidosDetalles",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidosDetalles",
                table: "PedidosDetalles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Componentes",
                table: "Componentes",
                column: "ComponenteId");

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    PedidoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NombreCliente = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Total = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.PedidoId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidosDetalles_PedidoId",
                table: "PedidosDetalles",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosDetalles_Componentes_ComponenteId",
                table: "PedidosDetalles",
                column: "ComponenteId",
                principalTable: "Componentes",
                principalColumn: "ComponenteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosDetalles_Pedidos_PedidoId",
                table: "PedidosDetalles",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "PedidoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDetalles_Componentes_ComponenteId",
                table: "PedidosDetalles");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosDetalles_Pedidos_PedidoId",
                table: "PedidosDetalles");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidosDetalles",
                table: "PedidosDetalles");

            migrationBuilder.DropIndex(
                name: "IX_PedidosDetalles_PedidoId",
                table: "PedidosDetalles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Componentes",
                table: "Componentes");

            migrationBuilder.RenameTable(
                name: "PedidosDetalles",
                newName: "PedidosDetalle");

            migrationBuilder.RenameTable(
                name: "Componentes",
                newName: "Componente");

            migrationBuilder.RenameColumn(
                name: "PedidoId",
                table: "PedidosDetalle",
                newName: "DetalleId");

            migrationBuilder.RenameIndex(
                name: "IX_PedidosDetalles_ComponenteId",
                table: "PedidosDetalle",
                newName: "IX_PedidosDetalle_ComponenteId");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PedidosDetalle",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AlterColumn<int>(
                name: "DetalleId",
                table: "PedidosDetalle",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidosDetalle",
                table: "PedidosDetalle",
                column: "DetalleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Componente",
                table: "Componente",
                column: "ComponenteId");

            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Cliente = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Total = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidosDetalle_Id",
                table: "PedidosDetalle",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosDetalle_Componente_ComponenteId",
                table: "PedidosDetalle",
                column: "ComponenteId",
                principalTable: "Componente",
                principalColumn: "ComponenteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosDetalle_Registros_Id",
                table: "PedidosDetalle",
                column: "Id",
                principalTable: "Registros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
