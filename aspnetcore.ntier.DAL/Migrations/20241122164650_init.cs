using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspnetcore.ntier.DAL.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApiUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DashboardUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardUsers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ApiUsers",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt" },
                values: new object[] { 1, "admin@admin.com", new byte[] { 124, 136, 157, 255, 214, 243, 249, 138, 141, 105, 211, 119, 43, 160, 177, 72, 155, 124, 162, 146, 206, 254, 56, 27, 177, 194, 63, 170, 18, 165, 76, 155, 116, 113, 244, 33, 54, 243, 55, 44, 252, 49, 15, 217, 234, 134, 131, 231, 252, 159, 223, 106, 235, 45, 126, 249, 84, 225, 251, 84, 140, 102, 134, 32 }, new byte[] { 204, 117, 210, 109, 76, 117, 216, 60, 33, 139, 74, 50, 81, 195, 4, 33, 94, 11, 26, 44, 96, 154, 241, 88, 111, 97, 153, 250, 160, 92, 63, 82, 125, 221, 109, 217, 66, 147, 0, 183, 36, 220, 219, 238, 116, 93, 118, 10, 254, 46, 58, 117, 253, 7, 195, 23, 133, 117, 223, 112, 180, 231, 7, 205, 54, 62, 5, 252, 144, 74, 53, 115, 91, 145, 161, 41, 4, 169, 23, 103, 5, 141, 58, 116, 210, 97, 199, 246, 42, 214, 133, 44, 175, 252, 238, 111, 92, 118, 0, 241, 163, 71, 225, 184, 28, 111, 175, 141, 168, 232, 199, 133, 211, 49, 189, 12, 24, 197, 33, 51, 28, 202, 104, 27, 243, 12, 230, 124 } });

            migrationBuilder.InsertData(
                table: "DashboardUsers",
                columns: new[] { "Id", "Email", "Name", "PasswordHash", "PasswordSalt" },
                values: new object[] { 1, "admin@admin.com", "Admin", new byte[] { 124, 136, 157, 255, 214, 243, 249, 138, 141, 105, 211, 119, 43, 160, 177, 72, 155, 124, 162, 146, 206, 254, 56, 27, 177, 194, 63, 170, 18, 165, 76, 155, 116, 113, 244, 33, 54, 243, 55, 44, 252, 49, 15, 217, 234, 134, 131, 231, 252, 159, 223, 106, 235, 45, 126, 249, 84, 225, 251, 84, 140, 102, 134, 32 }, new byte[] { 204, 117, 210, 109, 76, 117, 216, 60, 33, 139, 74, 50, 81, 195, 4, 33, 94, 11, 26, 44, 96, 154, 241, 88, 111, 97, 153, 250, 160, 92, 63, 82, 125, 221, 109, 217, 66, 147, 0, 183, 36, 220, 219, 238, 116, 93, 118, 10, 254, 46, 58, 117, 253, 7, 195, 23, 133, 117, 223, 112, 180, 231, 7, 205, 54, 62, 5, 252, 144, 74, 53, 115, 91, 145, 161, 41, 4, 169, 23, 103, 5, 141, 58, 116, 210, 97, 199, 246, 42, 214, 133, 44, 175, 252, 238, 111, 92, 118, 0, 241, 163, 71, 225, 184, 28, 111, 175, 141, 168, 232, 199, 133, 211, 49, 189, 12, 24, 197, 33, 51, 28, 202, 104, 27, 243, 12, 230, 124 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiUsers");

            migrationBuilder.DropTable(
                name: "DashboardUsers");
        }
    }
}
