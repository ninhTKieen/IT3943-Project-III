using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DeviceManagement.Migrations
{
    public partial class FixDeviceModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Devices",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Cost",
                table: "Devices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Devices",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Devices",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Devices",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "InstallationDate",
                table: "Devices",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastServiceDate",
                table: "Devices",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Latitude",
                table: "Devices",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "Longitude",
                table: "Devices",
                type: "float",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "Devices",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Devices",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Devices",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "PurchaseDate",
                table: "Devices",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Sku",
                table: "Devices",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Devices",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Devices",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Devices",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "WarrantyDate",
                table: "Devices",
                type: "datetime(6)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Cost",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "InstallationDate",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "LastServiceDate",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "PurchaseDate",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Sku",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "WarrantyDate",
                table: "Devices");
        }
    }
}
