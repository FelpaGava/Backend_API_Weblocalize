using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveParametrosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            if (migrationBuilder.ActiveProvider == "Microsoft.EntityFrameworkCore.SqlServer")
            {
                migrationBuilder.Sql("IF OBJECT_ID('Parametros', 'U') IS NOT NULL DROP TABLE [Parametros]");
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parametros",
                columns: table => new
                {
                    PARID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PARLINKGIT = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PARLINKLINKEDIN = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PARNOMEPROJETO = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametros", x => x.PARID);
                });
        }
    }
}
