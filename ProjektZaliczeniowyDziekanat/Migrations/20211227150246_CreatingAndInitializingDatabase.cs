using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjektZaliczeniowyDziekanat.Migrations
{
    public partial class CreatingAndInitializingDatabase : Migration
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
                name: "PlanZajec",
                columns: table => new
                {
                    ZajeciaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrupaNr = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NazwaZajec = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TerminZajec = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanZajec", x => x.ZajeciaID);
                    table.ForeignKey(
                        name: "FK_PlanZajec_Grupy_GrupaNr",
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
                    WykladowcaLogowanieID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WykladowcaID = table.Column<int>(type: "int", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Haslo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WykladowcyLogowanie", x => x.WykladowcaLogowanieID);
                    table.ForeignKey(
                        name: "FK_WykladowcyLogowanie_Wykladowcy_WykladowcaID",
                        column: x => x.WykladowcaID,
                        principalTable: "Wykladowcy",
                        principalColumn: "WykladowcaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Platnosci",
                columns: table => new
                {
                    PlatnoscID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    Kwota = table.Column<int>(type: "int", nullable: false),
                    DataPlatnosci = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platnosci", x => x.PlatnoscID);
                    table.ForeignKey(
                        name: "FK_Platnosci_Studenci_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Studenci",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudenciLogowanie",
                columns: table => new
                {
                    StudentLogowanieID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Haslo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudenciLogowanie", x => x.StudentLogowanieID);
                    table.ForeignKey(
                        name: "FK_StudenciLogowanie_Studenci_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Studenci",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudenciOceny",
                columns: table => new
                {
                    StudentOcenyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    ZajeciaID = table.Column<int>(type: "int", nullable: false),
                    Ocena = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudenciOceny", x => x.StudentOcenyID);
                    table.ForeignKey(
                        name: "FK_StudenciOceny_PlanZajec_ZajeciaID",
                        column: x => x.ZajeciaID,
                        principalTable: "PlanZajec",
                        principalColumn: "ZajeciaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudenciOceny_Studenci_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Studenci",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlanZajec_GrupaNr",
                table: "PlanZajec",
                column: "GrupaNr");

            migrationBuilder.CreateIndex(
                name: "IX_Platnosci_StudentID",
                table: "Platnosci",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Studenci_GrupaNr",
                table: "Studenci",
                column: "GrupaNr");

            migrationBuilder.CreateIndex(
                name: "IX_StudenciLogowanie_StudentID",
                table: "StudenciLogowanie",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_StudenciOceny_StudentID",
                table: "StudenciOceny",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_StudenciOceny_ZajeciaID",
                table: "StudenciOceny",
                column: "ZajeciaID");

            migrationBuilder.CreateIndex(
                name: "IX_WykladowcyLogowanie_WykladowcaID",
                table: "WykladowcyLogowanie",
                column: "WykladowcaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Platnosci");

            migrationBuilder.DropTable(
                name: "StudenciLogowanie");

            migrationBuilder.DropTable(
                name: "StudenciOceny");

            migrationBuilder.DropTable(
                name: "WykladowcyLogowanie");

            migrationBuilder.DropTable(
                name: "PlanZajec");

            migrationBuilder.DropTable(
                name: "Studenci");

            migrationBuilder.DropTable(
                name: "Wykladowcy");

            migrationBuilder.DropTable(
                name: "Grupy");
        }
    }
}
