using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Centerstone.MobileAppService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicantGUID",
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

            migrationBuilder.DropColumn(
                name: "UniqueImageId",
                table: "Images");

            migrationBuilder.AddColumn<byte[]>(
                name: "byteImage",
                table: "Images",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "byteImage",
                table: "Images");

            migrationBuilder.AddColumn<string>(
                name: "ApplicantGUID",
                table: "Images",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Images",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Images",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageType",
                table: "Images",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UniqueImageId",
                table: "Images",
                nullable: false,
                defaultValue: "");
        }
    }
}
