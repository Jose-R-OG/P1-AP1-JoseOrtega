using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace P1_AP1_JoseOrtega.Migrations
{
    /// <inheritdoc />
    public partial class Sexta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntradasHuacalesDetalle_EntradasHuacales_IdEntrada",
                table: "EntradasHuacalesDetalle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntradasHuacalesDetalle",
                table: "EntradasHuacalesDetalle");

            migrationBuilder.RenameTable(
                name: "EntradasHuacalesDetalle",
                newName: "entradasHuacalesDetalles");

            migrationBuilder.RenameIndex(
                name: "IX_EntradasHuacalesDetalle_IdEntrada",
                table: "entradasHuacalesDetalles",
                newName: "IX_entradasHuacalesDetalles_IdEntrada");

            migrationBuilder.AddPrimaryKey(
                name: "PK_entradasHuacalesDetalles",
                table: "entradasHuacalesDetalles",
                column: "DetalleId");

            migrationBuilder.CreateTable(
                name: "TiposHuacales",
                columns: table => new
                {
                    TipoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Existencia = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposHuacales", x => x.TipoId);
                });

            migrationBuilder.CreateTable(
                name: "EntradasHuacalesTiposHuacales",
                columns: table => new
                {
                    TipoHuacaleTipoId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradasHuacalesTiposHuacales", x => new { x.TipoHuacaleTipoId, x.TipoId });
                    table.ForeignKey(
                        name: "FK_EntradasHuacalesTiposHuacales_EntradasHuacales_TipoId",
                        column: x => x.TipoId,
                        principalTable: "EntradasHuacales",
                        principalColumn: "IdEntrada",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntradasHuacalesTiposHuacales_TiposHuacales_TipoHuacaleTipoId",
                        column: x => x.TipoHuacaleTipoId,
                        principalTable: "TiposHuacales",
                        principalColumn: "TipoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TiposHuacales",
                columns: new[] { "TipoId", "Descripcion", "Existencia" },
                values: new object[,]
                {
                    { 1, "Huacal verde pequeño", 0 },
                    { 2, "Huacal rojo pequeño", 0 },
                    { 3, "Huacal verde mediano", 0 },
                    { 4, "Huacal rojo mediano", 0 },
                    { 5, "Huacal verde Grande", 0 },
                    { 6, "Huacal rojo grande", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntradasHuacalesTiposHuacales_TipoId",
                table: "EntradasHuacalesTiposHuacales",
                column: "TipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_entradasHuacalesDetalles_EntradasHuacales_IdEntrada",
                table: "entradasHuacalesDetalles",
                column: "IdEntrada",
                principalTable: "EntradasHuacales",
                principalColumn: "IdEntrada",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_entradasHuacalesDetalles_EntradasHuacales_IdEntrada",
                table: "entradasHuacalesDetalles");

            migrationBuilder.DropTable(
                name: "EntradasHuacalesTiposHuacales");

            migrationBuilder.DropTable(
                name: "TiposHuacales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_entradasHuacalesDetalles",
                table: "entradasHuacalesDetalles");

            migrationBuilder.RenameTable(
                name: "entradasHuacalesDetalles",
                newName: "EntradasHuacalesDetalle");

            migrationBuilder.RenameIndex(
                name: "IX_entradasHuacalesDetalles_IdEntrada",
                table: "EntradasHuacalesDetalle",
                newName: "IX_EntradasHuacalesDetalle_IdEntrada");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntradasHuacalesDetalle",
                table: "EntradasHuacalesDetalle",
                column: "DetalleId");

            migrationBuilder.AddForeignKey(
                name: "FK_EntradasHuacalesDetalle_EntradasHuacales_IdEntrada",
                table: "EntradasHuacalesDetalle",
                column: "IdEntrada",
                principalTable: "EntradasHuacales",
                principalColumn: "IdEntrada",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
