using Microsoft.EntityFrameworkCore.Migrations;

namespace Async_Inn.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_Room_RoomID1",
                table: "HotelRoom");

            migrationBuilder.DropIndex(
                name: "IX_HotelRoom_RoomID1",
                table: "HotelRoom");

            migrationBuilder.DropColumn(
                name: "RoomID1",
                table: "HotelRoom");

            migrationBuilder.AlterColumn<int>(
                name: "RoomID",
                table: "HotelRoom",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoom_RoomID",
                table: "HotelRoom",
                column: "RoomID");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_Room_RoomID",
                table: "HotelRoom",
                column: "RoomID",
                principalTable: "Room",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelRoom_Room_RoomID",
                table: "HotelRoom");

            migrationBuilder.DropIndex(
                name: "IX_HotelRoom_RoomID",
                table: "HotelRoom");

            migrationBuilder.AlterColumn<decimal>(
                name: "RoomID",
                table: "HotelRoom",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "RoomID1",
                table: "HotelRoom",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelRoom_RoomID1",
                table: "HotelRoom",
                column: "RoomID1");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelRoom_Room_RoomID1",
                table: "HotelRoom",
                column: "RoomID1",
                principalTable: "Room",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
