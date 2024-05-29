using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trek_Booking_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsVerify",
                table: "SupplierStaff",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVerify",
                table: "SupplierStaff");
        }
    }
}
