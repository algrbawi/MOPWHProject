using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspnetcore.ntier.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Add_Last_Failed_Login_Time : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastFailedLogin",
                table: "DashboardUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "DashboardUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastFailedLogin",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastFailedLogin",
                table: "DashboardUsers");
        }
    }
}
