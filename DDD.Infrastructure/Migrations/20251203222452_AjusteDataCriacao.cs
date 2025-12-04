using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjusteDataCriacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LOCDATACRIACAO",
                table: "Locais",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UFDATACRIACAO",
                table: "Estados",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "CIDDATACRIACAO",
                table: "Cidades",
                type: "datetime",
                nullable: false,
                defaultValueSql: "GETDATE()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LOCDATACRIACAO",
                table: "Locais");

            migrationBuilder.DropColumn(
                name: "UFDATACRIACAO",
                table: "Estados");

            migrationBuilder.DropColumn(
                name: "CIDDATACRIACAO",
                table: "Cidades");
        }
    }
}
