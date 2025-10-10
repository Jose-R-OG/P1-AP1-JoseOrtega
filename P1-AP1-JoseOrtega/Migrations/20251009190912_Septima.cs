using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P1_AP1_JoseOrtega.Migrations
{
    /// <inheritdoc />
    public partial class Septima : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Precio",
                table: "entradasHuacalesDetalles",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Precio",
                table: "entradasHuacalesDetalles",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");
        }
    }
}
