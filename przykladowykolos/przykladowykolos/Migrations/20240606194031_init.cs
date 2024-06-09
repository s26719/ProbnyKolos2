using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace przykladowykolos.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Muzyk",
                columns: table => new
                {
                    IdMuzyk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Pseudonim = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Muzyk", x => x.IdMuzyk);
                });

            migrationBuilder.CreateTable(
                name: "Wytwornia",
                columns: table => new
                {
                    IdWytwornia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wytwornia", x => x.IdWytwornia);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    IdAlbum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaAlbumu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DataWydania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdWytwornia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.IdAlbum);
                    table.ForeignKey(
                        name: "FK_Album_Wytwornia_IdWytwornia",
                        column: x => x.IdWytwornia,
                        principalTable: "Wytwornia",
                        principalColumn: "IdWytwornia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Utwor",
                columns: table => new
                {
                    IdUtwor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaUtworu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CzasTrwania = table.Column<float>(type: "real", nullable: false),
                    IdAlbum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utwor", x => x.IdUtwor);
                    table.ForeignKey(
                        name: "FK_Utwor_Album_IdAlbum",
                        column: x => x.IdAlbum,
                        principalTable: "Album",
                        principalColumn: "IdAlbum",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WykonawcaUtworu",
                columns: table => new
                {
                    IdMuzyk = table.Column<int>(type: "int", nullable: false),
                    IdUtwor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WykonawcaUtworu", x => new { x.IdMuzyk, x.IdUtwor });
                    table.ForeignKey(
                        name: "FK_WykonawcaUtworu_Muzyk_IdMuzyk",
                        column: x => x.IdMuzyk,
                        principalTable: "Muzyk",
                        principalColumn: "IdMuzyk",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WykonawcaUtworu_Utwor_IdUtwor",
                        column: x => x.IdUtwor,
                        principalTable: "Utwor",
                        principalColumn: "IdUtwor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_IdWytwornia",
                table: "Album",
                column: "IdWytwornia");

            migrationBuilder.CreateIndex(
                name: "IX_Utwor_IdAlbum",
                table: "Utwor",
                column: "IdAlbum");

            migrationBuilder.CreateIndex(
                name: "IX_WykonawcaUtworu_IdUtwor",
                table: "WykonawcaUtworu",
                column: "IdUtwor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WykonawcaUtworu");

            migrationBuilder.DropTable(
                name: "Muzyk");

            migrationBuilder.DropTable(
                name: "Utwor");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Wytwornia");
        }
    }
}
