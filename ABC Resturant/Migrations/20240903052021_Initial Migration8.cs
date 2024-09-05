using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABC_Resturant.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Reservations_ReservationId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customers_CustomerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Resturants_ResturantId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.RenameTable(
                name: "Reservations",
                newName: "Reservationss");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_ResturantId",
                table: "Reservationss",
                newName: "IX_Reservationss_ResturantId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservationss",
                newName: "IX_Reservationss_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservationss",
                table: "Reservationss",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Reservationss_ReservationId",
                table: "Orders",
                column: "ReservationId",
                principalTable: "Reservationss",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservationss_Customers_CustomerId",
                table: "Reservationss",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservationss_Resturants_ResturantId",
                table: "Reservationss",
                column: "ResturantId",
                principalTable: "Resturants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Reservationss_ReservationId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservationss_Customers_CustomerId",
                table: "Reservationss");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservationss_Resturants_ResturantId",
                table: "Reservationss");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservationss",
                table: "Reservationss");

            migrationBuilder.RenameTable(
                name: "Reservationss",
                newName: "Reservations");

            migrationBuilder.RenameIndex(
                name: "IX_Reservationss_ResturantId",
                table: "Reservations",
                newName: "IX_Reservations_ResturantId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservationss_CustomerId",
                table: "Reservations",
                newName: "IX_Reservations_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Reservations_ReservationId",
                table: "Orders",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customers_CustomerId",
                table: "Reservations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Resturants_ResturantId",
                table: "Reservations",
                column: "ResturantId",
                principalTable: "Resturants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
