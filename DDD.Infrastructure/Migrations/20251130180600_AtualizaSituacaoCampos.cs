using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaSituacaoCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LOCSITUACAO",
                table: "Locais",
                type: "char(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UFSITUACAO",
                table: "Estados",
                type: "char(1)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CIDSITUACAO",
                table: "Cidades",
                type: "char(1)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LOCSITUACAO",
                table: "Locais");

            migrationBuilder.DropColumn(
                name: "UFSITUACAO",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "CIDSITUACAO",
                table: "Cidades");
        }
    }
}
