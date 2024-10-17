﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCoreApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableOgretmenler : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kurslar_Ogretmenler_ogretmenId",
                table: "Kurslar");

            migrationBuilder.AlterColumn<int>(
                name: "ogretmenId",
                table: "Kurslar",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Kurslar_Ogretmenler_ogretmenId",
                table: "Kurslar",
                column: "ogretmenId",
                principalTable: "Ogretmenler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kurslar_Ogretmenler_ogretmenId",
                table: "Kurslar");

            migrationBuilder.AlterColumn<int>(
                name: "ogretmenId",
                table: "Kurslar",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Kurslar_Ogretmenler_ogretmenId",
                table: "Kurslar",
                column: "ogretmenId",
                principalTable: "Ogretmenler",
                principalColumn: "Id");
        }
    }
}
