using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DDD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    UFID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UFNOME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UFSIGLA = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.UFID);
                });

            migrationBuilder.CreateTable(
                name: "Cidades",
                columns: table => new
                {
                    CIDID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CIDNOME = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CIDUF = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cidades", x => x.CIDID);
                    table.ForeignKey(
                        name: "FK_Cidades_Estados_CIDUF",
                        column: x => x.CIDUF,
                        principalTable: "Estados",
                        principalColumn: "UFID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locais",
                columns: table => new
                {
                    LOCID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LOCNOME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LOCCID = table.Column<int>(type: "int", nullable: false),
                    LOCUF = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locais", x => x.LOCID);
                    table.ForeignKey(
                        name: "FK_Locais_Cidades_LOCCID",
                        column: x => x.LOCCID,
                        principalTable: "Cidades",
                        principalColumn: "CIDID");
                    table.ForeignKey(
                        name: "FK_Locais_Estados_LOCUF",
                        column: x => x.LOCUF,
                        principalTable: "Estados",
                        principalColumn: "UFID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cidades_CIDUF",
                table: "Cidades",
                column: "CIDUF");

            migrationBuilder.CreateIndex(
                name: "IX_Locais_LOCCID",
                table: "Locais",
                column: "LOCCID");

            migrationBuilder.CreateIndex(
                name: "IX_Locais_LOCUF",
                table: "Locais",
                column: "LOCUF");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locais");

            migrationBuilder.DropTable(
                name: "Cidades");

            migrationBuilder.DropTable(
                name: "Estados");
        }
    }
}
