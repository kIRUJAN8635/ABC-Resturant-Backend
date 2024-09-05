using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABC_Resturant.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Reservationss_ReservationId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Reservationss");

            migrationBuilder.RenameColumn(
                name: "ReservationId",
                table: "Orders",
                newName: "TableBookingID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ReservationId",
                table: "Orders",
                newName: "IX_Orders_TableBookingID");

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ResturantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Resturants_ResturantId",
                        column: x => x.ResturantId,
                        principalTable: "Resturants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CustomerId",
                table: "Reviews",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ResturantId",
                table: "Reviews",
                column: "ResturantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_TableBookings_TableBookingID",
                table: "Orders",
                column: "TableBookingID",
                principalTable: "TableBookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_TableBookings_TableBookingID",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.RenameColumn(
                name: "TableBookingID",
                table: "Orders",
                newName: "ReservationId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_TableBookingID",
                table: "Orders",
                newName: "IX_Orders_ReservationId");

            migrationBuilder.CreateTable(
                name: "Reservationss",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ResturantId = table.Column<int>(type: "int", nullable: false),
                    CustiomerId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfTable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservationss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservationss_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservationss_Resturants_ResturantId",
                        column: x => x.ResturantId,
                        principalTable: "Resturants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservationss_CustomerId",
                table: "Reservationss",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservationss_ResturantId",
                table: "Reservationss",
                column: "ResturantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Reservationss_ReservationId",
                table: "Orders",
                column: "ReservationId",
                principalTable: "Reservationss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
