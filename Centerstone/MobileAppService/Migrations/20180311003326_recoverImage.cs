using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Centerstone.MobileAppService.Migrations
{
    public partial class recoverImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "byteImage",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "ApplicantGuid",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageType",
                table: "Images",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicantGuid",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ImageType",
                table: "Images");

            migrationBuilder.AddColumn<byte[]>(
                name: "byteImage",
                table: "Images",
                nullable: true);
        }
    }
}
