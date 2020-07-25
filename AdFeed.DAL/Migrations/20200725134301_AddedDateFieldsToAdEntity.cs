using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdFeed.DAL.Migrations
{
    public partial class AddedDateFieldsToAdEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Ads");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOnDate",
                table: "Ads",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOnDate",
                table: "Ads",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOnDate",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "UpdatedOnDate",
                table: "Ads");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Ads",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
