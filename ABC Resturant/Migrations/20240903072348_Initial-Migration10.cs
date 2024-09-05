using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABC_Resturant.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TableBookings_Resturants_ResturantId",
                table: "TableBookings");

            migrationBuilder.DropIndex(
                name: "IX_TableBookings_ResturantId",
                table: "TableBookings");

            migrationBuilder.DropColumn(
                name: "ResturantId",
                table: "TableBookings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResturantId",
                table: "TableBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TableBookings_ResturantId",
                table: "TableBookings",
                column: "ResturantId");

            migrationBuilder.AddForeignKey(
                name: "FK_TableBookings_Resturants_ResturantId",
                table: "TableBookings",
                column: "ResturantId",
                principalTable: "Resturants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
