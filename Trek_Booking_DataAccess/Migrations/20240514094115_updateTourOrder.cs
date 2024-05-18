﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trek_Booking_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class updateTourOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "TourOrder",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "TourOrder");
        }
    }
}