using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreApp.Migrations
{
    /// <inheritdoc />
    public partial class AddTableOgretmen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ogretmenId",
                table: "Kurslar",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ogretmenler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ogretmenAd = table.Column<string>(type: "TEXT", nullable: true),
                    ogretmenSoyd = table.Column<string>(type: "TEXT", nullable: true),
                    ogretmenMail = table.Column<string>(type: "TEXT", nullable: true),
                    ogretmenTel = table.Column<string>(type: "TEXT", nullable: true),
                    BaslamaTarihi = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ogretmenler", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kurslar_ogretmenId",
                table: "Kurslar",
                column: "ogretmenId");

            migrationBuilder.CreateIndex(
                name: "IX_KursKayitlari_KursId",
                table: "KursKayitlari",
                column: "KursId");

            migrationBuilder.CreateIndex(
                name: "IX_KursKayitlari_OgrenciId",
                table: "KursKayitlari",
                column: "OgrenciId");

            migrationBuilder.AddForeignKey(
                name: "FK_KursKayitlari_Kurslar_KursId",
                table: "KursKayitlari",
                column: "KursId",
                principalTable: "Kurslar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_KursKayitlari_Ogrenciler_OgrenciId",
                table: "KursKayitlari",
                column: "OgrenciId",
                principalTable: "Ogrenciler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kurslar_Ogretmenler_ogretmenId",
                table: "Kurslar",
                column: "ogretmenId",
                principalTable: "Ogretmenler",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KursKayitlari_Kurslar_KursId",
                table: "KursKayitlari");

            migrationBuilder.DropForeignKey(
                name: "FK_KursKayitlari_Ogrenciler_OgrenciId",
                table: "KursKayitlari");

            migrationBuilder.DropForeignKey(
                name: "FK_Kurslar_Ogretmenler_ogretmenId",
                table: "Kurslar");

            migrationBuilder.DropTable(
                name: "Ogretmenler");

            migrationBuilder.DropIndex(
                name: "IX_Kurslar_ogretmenId",
                table: "Kurslar");

            migrationBuilder.DropIndex(
                name: "IX_KursKayitlari_KursId",
                table: "KursKayitlari");

            migrationBuilder.DropIndex(
                name: "IX_KursKayitlari_OgrenciId",
                table: "KursKayitlari");

            migrationBuilder.DropColumn(
                name: "ogretmenId",
                table: "Kurslar");
        }
    }
}
