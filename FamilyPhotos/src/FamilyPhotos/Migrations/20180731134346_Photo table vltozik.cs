using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FamilyPhotos.Migrations
{
    public partial class Phototablevltozik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FaceBookProfil",
                table: "Photos",
                maxLength: 40,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Company",
                table: "Photos",
                maxLength: 40,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FaceBookProfil",
                table: "Photos");

            migrationBuilder.AlterColumn<string>(
                name: "Company",
                table: "Photos",
                maxLength: 40,
                nullable: false);
        }
    }
}
