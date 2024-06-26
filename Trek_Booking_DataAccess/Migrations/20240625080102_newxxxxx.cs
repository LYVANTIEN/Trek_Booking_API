using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trek_Booking_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class newxxxxx : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "orderHotelHeaderId",
                table: "OrderHotelDetail",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderHotelDetail_orderHotelHeaderId",
                table: "OrderHotelDetail",
                column: "orderHotelHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderHotelDetail_OrderHotelHeader_orderHotelHeaderId",
                table: "OrderHotelDetail",
                column: "orderHotelHeaderId",
                principalTable: "OrderHotelHeader",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderHotelDetail_OrderHotelHeader_orderHotelHeaderId",
                table: "OrderHotelDetail");

            migrationBuilder.DropIndex(
                name: "IX_OrderHotelDetail_orderHotelHeaderId",
                table: "OrderHotelDetail");

            migrationBuilder.DropColumn(
                name: "orderHotelHeaderId",
                table: "OrderHotelDetail");
        }
    }
}
