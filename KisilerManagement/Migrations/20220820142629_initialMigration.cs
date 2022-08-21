using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace KisilerManagement.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BilgiTipleri",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Tanim = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BilgiTipleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kisiler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UUID = table.Column<int>(nullable: false),
                    Ad = table.Column<string>(nullable: true),
                    Soyad = table.Column<string>(nullable: true),
                    Firma = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kisiler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IletisimBilgileri",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    KisiID = table.Column<int>(nullable: false),
                    BilgiTipiID = table.Column<int>(nullable: false),
                    BilgiIcerigi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IletisimBilgileri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IletisimBilgileri_BilgiTipleri_BilgiTipiID",
                        column: x => x.BilgiTipiID,
                        principalTable: "BilgiTipleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IletisimBilgileri_Kisiler_KisiID",
                        column: x => x.KisiID,
                        principalTable: "Kisiler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IletisimBilgileri_BilgiTipiID",
                table: "IletisimBilgileri",
                column: "BilgiTipiID");

            migrationBuilder.CreateIndex(
                name: "IX_IletisimBilgileri_KisiID",
                table: "IletisimBilgileri",
                column: "KisiID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IletisimBilgileri");

            migrationBuilder.DropTable(
                name: "BilgiTipleri");

            migrationBuilder.DropTable(
                name: "Kisiler");
        }
    }
}
