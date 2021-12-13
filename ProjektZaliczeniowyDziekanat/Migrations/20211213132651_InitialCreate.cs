using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektZaliczeniowyDziekanat.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grupy",
                columns: table => new
                {
                    GrupaNr = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grupy", x => x.GrupaNr);
                });

            migrationBuilder.CreateTable(
                name: "Wykladowcy",
                columns: table => new
                {
                    WykladowcaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StopienNaukowy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PESEL = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wykladowcy", x => x.WykladowcaID);
                });

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

            migrationBuilder.CreateTable(
                name: "Studenci",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumerIndeksu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataUrodzenia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PESEL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrupaNr = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studenci", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Studenci_Grupy_GrupaNr",
                        column: x => x.GrupaNr,
                        principalTable: "Grupy",
                        principalColumn: "GrupaNr",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WykladowcyLogowanie",
                columns: table => new
                {
                    WykladowcaID = table.Column<int>(type: "int", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Haslo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_WykladowcyLogowanie_Wykladowcy_WykladowcaID",
                        column: x => x.WykladowcaID,
                        principalTable: "Wykladowcy",
                        principalColumn: "WykladowcaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zajecia",
                columns: table => new
                {
                    ZajeciaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaZajec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TerminZajec = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WykladowcaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zajecia", x => x.ZajeciaID);
                    table.ForeignKey(
                        name: "FK_Zajecia_Wykladowcy_WykladowcaID",
                        column: x => x.WykladowcaID,
                        principalTable: "Wykladowcy",
                        principalColumn: "WykladowcaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Finanse",
                columns: table => new
                {
                    PlatnoscID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kwota = table.Column<int>(type: "int", nullable: false),
                    DataPlatnosci = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finanse", x => x.PlatnoscID);
                    table.ForeignKey(
                        name: "FK_Finanse_Studenci_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Studenci",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudenciLogowanie",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Haslo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_StudenciLogowanie_Studenci_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Studenci",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentOceny",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    ZajeciaID = table.Column<int>(type: "int", nullable: false),
                    Ocena = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_StudentOceny_Studenci_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Studenci",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentOceny_Zajecia_ZajeciaID",
                        column: x => x.ZajeciaID,
                        principalTable: "Zajecia",
                        principalColumn: "ZajeciaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Finanse_StudentID",
                table: "Finanse",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_GrupaZajecia_GrupaNr",
                table: "GrupaZajecia",
                column: "GrupaNr");

            migrationBuilder.CreateIndex(
                name: "IX_Studenci_GrupaNr",
                table: "Studenci",
                column: "GrupaNr");

            migrationBuilder.CreateIndex(
                name: "IX_StudenciLogowanie_StudentID",
                table: "StudenciLogowanie",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentOceny_StudentID",
                table: "StudentOceny",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentOceny_ZajeciaID",
                table: "StudentOceny",
                column: "ZajeciaID");

            migrationBuilder.CreateIndex(
                name: "IX_WykladowcyLogowanie_WykladowcaID",
                table: "WykladowcyLogowanie",
                column: "WykladowcaID");

            migrationBuilder.CreateIndex(
                name: "IX_Zajecia_WykladowcaID",
                table: "Zajecia",
                column: "WykladowcaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Finanse");

            migrationBuilder.DropTable(
                name: "GrupaZajecia");

            migrationBuilder.DropTable(
                name: "StudenciLogowanie");

            migrationBuilder.DropTable(
                name: "StudentOceny");

            migrationBuilder.DropTable(
                name: "WykladowcyLogowanie");

            migrationBuilder.DropTable(
                name: "Studenci");

            migrationBuilder.DropTable(
                name: "Zajecia");

            migrationBuilder.DropTable(
                name: "Grupy");

            migrationBuilder.DropTable(
                name: "Wykladowcy");
        }
    }
}
