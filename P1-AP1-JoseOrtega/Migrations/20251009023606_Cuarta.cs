using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P1_AP1_JoseOrtega.Migrations
{
    /// <inheritdoc />
    public partial class Cuarta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntradasHuacalesDetalle",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EntradaId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<string>(type: "TEXT", nullable: false),
                    IdEntrada = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradasHuacalesDetalle", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_EntradasHuacalesDetalle_EntradasHuacales_IdEntrada",
                        column: x => x.IdEntrada,
                        principalTable: "EntradasHuacales",
                        principalColumn: "IdEntrada",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntradasHuacalesDetalle_IdEntrada",
                table: "EntradasHuacalesDetalle",
                column: "IdEntrada");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntradasHuacalesDetalle");
        }
    }
}
