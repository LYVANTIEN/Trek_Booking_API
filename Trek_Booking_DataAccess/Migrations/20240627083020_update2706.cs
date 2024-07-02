using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trek_Booking_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class update2706 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BankAccount",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankName",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BankNumber",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "OrderTourHeader",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Process",
                table: "OrderTourHeader",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Completed",
                table: "OrderHotelHeader",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Process",
                table: "OrderHotelHeader",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankAccount",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "BankName",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "BankNumber",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Completed",
                table: "OrderTourHeader");

            migrationBuilder.DropColumn(
                name: "Process",
                table: "OrderTourHeader");

            migrationBuilder.DropColumn(
                name: "Completed",
                table: "OrderHotelHeader");

            migrationBuilder.DropColumn(
                name: "Process",
                table: "OrderHotelHeader");
        }
    }
}
