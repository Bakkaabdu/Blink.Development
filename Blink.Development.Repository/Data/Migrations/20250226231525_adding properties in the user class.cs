using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blink.Development.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class addingpropertiesintheuserclass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "IdentityCardPhoto",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Deliveries");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Deliveries");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Deliveries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdentityCardPhoto",
                table: "Deliveries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Deliveries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Deliveries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
