using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektZaliczeniowyDziekanat.Migrations
{
    public partial class UsuniecieModeluZajeciaOcenyOrazInicjalizacjaBazyDanych : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrupaZajecia");

            migrationBuilder.AddColumn<string>(
                name: "GrupaNr",
                table: "Zajecia",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Zajecia_GrupaNr",
                table: "Zajecia",
                column: "GrupaNr");

            migrationBuilder.AddForeignKey(
                name: "FK_Zajecia_Grupy_GrupaNr",
                table: "Zajecia",
                column: "GrupaNr",
                principalTable: "Grupy",
                principalColumn: "GrupaNr",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zajecia_Grupy_GrupaNr",
                table: "Zajecia");

            migrationBuilder.DropIndex(
                name: "IX_Zajecia_GrupaNr",
                table: "Zajecia");

            migrationBuilder.DropColumn(
                name: "GrupaNr",
                table: "Zajecia");

            migrationBuilder.CreateTable(
                name: "GrupaZajecia",
                columns: table => new
                {
                    GrupaNr = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_GrupaZajecia_Grupy_GrupaNr",
                        column: x => x.GrupaNr,
                        principalTable: "Grupy",
                        principalColumn: "GrupaNr",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrupaZajecia_GrupaNr",
                table: "GrupaZajecia",
                column: "GrupaNr");
        }
    }
}
