using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspnetcore.ntier.DAL.Migrations
{
    /// <inheritdoc />
    public partial class add_IsActive_and_LastPasswordUpdate_columns_on_dasgboardusertbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "DashboardUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateOnly>(
                name: "LastUpdatePassword",
                table: "DashboardUsers",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.UpdateData(
                table: "DashboardUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsActive", "LastUpdatePassword" },
                values: new object[] { false, new DateOnly(1, 1, 1) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "DashboardUsers");

            migrationBuilder.DropColumn(
                name: "LastUpdatePassword",
                table: "DashboardUsers");
        }
    }
}
