using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ABC_Resturant.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Queries_Staffs_StaffId1",
                table: "Queries");

            migrationBuilder.DropIndex(
                name: "IX_Queries_StaffId1",
                table: "Queries");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Queries");

            migrationBuilder.DropColumn(
                name: "StaffId1",
                table: "Queries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "Queries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StaffId1",
                table: "Queries",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Queries_StaffId1",
                table: "Queries",
                column: "StaffId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Queries_Staffs_StaffId1",
                table: "Queries",
                column: "StaffId1",
                principalTable: "Staffs",
                principalColumn: "Id");
        }
    }
}
