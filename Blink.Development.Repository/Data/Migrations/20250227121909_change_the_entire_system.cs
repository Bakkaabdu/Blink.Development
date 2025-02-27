using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blink.Development.Repository.Data.Migrations
{
    /// <inheritdoc />
    public partial class change_the_entire_system : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Stores_StoreId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Missions_Stores_StoreId",
                table: "Missions");

            migrationBuilder.DropForeignKey(
                name: "FK_Delivery_MoneyTransaction",
                table: "MoneyTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_MoneyTransactions_Stores_StoreId",
                table: "MoneyTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Deliveries_DeliveryId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Stores_StoreId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_StoreId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_MoneyTransactions_DeliveryId",
                table: "MoneyTransactions");

            migrationBuilder.DropIndex(
                name: "IX_MoneyTransactions_StoreId",
                table: "MoneyTransactions");

            migrationBuilder.DropIndex(
                name: "IX_Missions_StoreId",
                table: "Missions");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_StoreId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "MoneyTransactions");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "MoneyTransactions");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Inventory");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryUserId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserStoreId",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DeliveryUserId",
                table: "MoneyTransactions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserStoreId",
                table: "MoneyTransactions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserStoreId",
                table: "Missions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserStoreId",
                table: "Inventory",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryBranchId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryMoneyTransactionId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeliveryPhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MissionId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StoreBranchId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StoreMoneyTransactionId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StorePhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryUserId",
                table: "Orders",
                column: "DeliveryUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserStoreId",
                table: "Orders",
                column: "UserStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyTransactions_DeliveryUserId",
                table: "MoneyTransactions",
                column: "DeliveryUserId",
                unique: true,
                filter: "[DeliveryUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyTransactions_UserStoreId",
                table: "MoneyTransactions",
                column: "UserStoreId",
                unique: true,
                filter: "[UserStoreId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_UserStoreId",
                table: "Missions",
                column: "UserStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_UserStoreId",
                table: "Inventory",
                column: "UserStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DeliveryBranchId",
                table: "AspNetUsers",
                column: "DeliveryBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_StoreBranchId",
                table: "AspNetUsers",
                column: "StoreBranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Branches_DeliveryBranchId",
                table: "AspNetUsers",
                column: "DeliveryBranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Branches_StoreBranchId",
                table: "AspNetUsers",
                column: "StoreBranchId",
                principalTable: "Branches",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_AspNetUsers_UserStoreId",
                table: "Inventory",
                column: "UserStoreId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_AspNetUsers_UserStoreId",
                table: "Missions",
                column: "UserStoreId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Delivery_MoneyTransaction",
                table: "MoneyTransactions",
                column: "DeliveryUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyTransactions_AspNetUsers_UserStoreId",
                table: "MoneyTransactions",
                column: "UserStoreId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_DeliveryUserId",
                table: "Orders",
                column: "DeliveryUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_UserStoreId",
                table: "Orders",
                column: "UserStoreId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Branches_DeliveryBranchId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Branches_StoreBranchId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_AspNetUsers_UserStoreId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Missions_AspNetUsers_UserStoreId",
                table: "Missions");

            migrationBuilder.DropForeignKey(
                name: "FK_Delivery_MoneyTransaction",
                table: "MoneyTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_MoneyTransactions_AspNetUsers_UserStoreId",
                table: "MoneyTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_DeliveryUserId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_UserStoreId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryUserId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserStoreId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_MoneyTransactions_DeliveryUserId",
                table: "MoneyTransactions");

            migrationBuilder.DropIndex(
                name: "IX_MoneyTransactions_UserStoreId",
                table: "MoneyTransactions");

            migrationBuilder.DropIndex(
                name: "IX_Missions_UserStoreId",
                table: "Missions");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_UserStoreId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DeliveryBranchId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_StoreBranchId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeliveryUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UserStoreId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeliveryUserId",
                table: "MoneyTransactions");

            migrationBuilder.DropColumn(
                name: "UserStoreId",
                table: "MoneyTransactions");

            migrationBuilder.DropColumn(
                name: "UserStoreId",
                table: "Missions");

            migrationBuilder.DropColumn(
                name: "UserStoreId",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeliveryAddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeliveryBranchId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeliveryMoneyTransactionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DeliveryPhoneNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MissionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StoreAddress",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StoreBranchId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StoreMoneyTransactionId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StorePhoneNumber",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DeliveryId",
                table: "MoneyTransactions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "MoneyTransactions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "Missions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                table: "Inventory",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MoneyTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliveries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Deliveries_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    MissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MoneyTransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Stores_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryId",
                table: "Orders",
                column: "DeliveryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StoreId",
                table: "Orders",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyTransactions_DeliveryId",
                table: "MoneyTransactions",
                column: "DeliveryId",
                unique: true,
                filter: "[DeliveryId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MoneyTransactions_StoreId",
                table: "MoneyTransactions",
                column: "StoreId",
                unique: true,
                filter: "[StoreId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_StoreId",
                table: "Missions",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_StoreId",
                table: "Inventory",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_BranchId",
                table: "Deliveries",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_UserId",
                table: "Deliveries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_BranchId",
                table: "Stores",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_UserId",
                table: "Stores",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Stores_StoreId",
                table: "Inventory",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Missions_Stores_StoreId",
                table: "Missions",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Delivery_MoneyTransaction",
                table: "MoneyTransactions",
                column: "DeliveryId",
                principalTable: "Deliveries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MoneyTransactions_Stores_StoreId",
                table: "MoneyTransactions",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Deliveries_DeliveryId",
                table: "Orders",
                column: "DeliveryId",
                principalTable: "Deliveries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Stores_StoreId",
                table: "Orders",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id");
        }
    }
}
