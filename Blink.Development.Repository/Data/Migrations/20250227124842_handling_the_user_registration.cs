using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blink.Development.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class handling_the_user_registration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MissionId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "TypeOfUser",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TypeOfUser",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "MissionId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
