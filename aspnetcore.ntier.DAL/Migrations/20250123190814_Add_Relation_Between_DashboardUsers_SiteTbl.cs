using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace aspnetcore.ntier.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Add_Relation_Between_DashboardUsers_SiteTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSuperAdmin",
                table: "DashboardUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "AccessUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DashboardUserId = table.Column<int>(type: "int", nullable: false),
                    SiteTblId = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccessUser_DashboardUsers_DashboardUserId",
                        column: x => x.DashboardUserId,
                        principalTable: "DashboardUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccessUser_Site_TBL_SiteTblId",
                        column: x => x.SiteTblId,
                        principalTable: "Site_TBL",
                        principalColumn: "Site_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "ApiUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 31, 59, 124, 137, 137, 94, 98, 253, 201, 169, 80, 215, 29, 142, 240, 175, 60, 172, 231, 9, 67, 233, 27, 141, 103, 105, 135, 169, 176, 37, 147, 167, 154, 4, 11, 95, 152, 82, 162, 14, 125, 70, 235, 19, 203, 11, 111, 26, 255, 83, 60, 130, 36, 26, 92, 182, 175, 176, 248, 121, 29, 54, 202, 42 }, new byte[] { 92, 108, 98, 55, 74, 202, 10, 81, 218, 129, 105, 14, 42, 85, 123, 253, 147, 57, 48, 147, 239, 118, 147, 30, 214, 237, 173, 236, 177, 59, 115, 236, 185, 5, 68, 109, 81, 188, 71, 184, 55, 222, 15, 232, 100, 62, 198, 62, 2, 161, 73, 76, 217, 130, 228, 55, 251, 139, 46, 7, 203, 159, 78, 93, 198, 116, 8, 193, 169, 214, 32, 114, 221, 44, 98, 153, 177, 54, 6, 87, 212, 40, 88, 73, 186, 95, 50, 148, 169, 153, 241, 219, 1, 209, 139, 32, 17, 65, 174, 173, 12, 42, 142, 14, 90, 230, 156, 150, 226, 15, 130, 104, 113, 107, 118, 196, 65, 125, 17, 65, 123, 100, 242, 97, 216, 47, 167, 66 } });

            migrationBuilder.UpdateData(
                table: "DashboardUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IsSuperAdmin", "PasswordHash", "PasswordSalt" },
                values: new object[] { false, new byte[] { 31, 59, 124, 137, 137, 94, 98, 253, 201, 169, 80, 215, 29, 142, 240, 175, 60, 172, 231, 9, 67, 233, 27, 141, 103, 105, 135, 169, 176, 37, 147, 167, 154, 4, 11, 95, 152, 82, 162, 14, 125, 70, 235, 19, 203, 11, 111, 26, 255, 83, 60, 130, 36, 26, 92, 182, 175, 176, 248, 121, 29, 54, 202, 42 }, new byte[] { 92, 108, 98, 55, 74, 202, 10, 81, 218, 129, 105, 14, 42, 85, 123, 253, 147, 57, 48, 147, 239, 118, 147, 30, 214, 237, 173, 236, 177, 59, 115, 236, 185, 5, 68, 109, 81, 188, 71, 184, 55, 222, 15, 232, 100, 62, 198, 62, 2, 161, 73, 76, 217, 130, 228, 55, 251, 139, 46, 7, 203, 159, 78, 93, 198, 116, 8, 193, 169, 214, 32, 114, 221, 44, 98, 153, 177, 54, 6, 87, 212, 40, 88, 73, 186, 95, 50, 148, 169, 153, 241, 219, 1, 209, 139, 32, 17, 65, 174, 173, 12, 42, 142, 14, 90, 230, 156, 150, 226, 15, 130, 104, 113, 107, 118, 196, 65, 125, 17, 65, 123, 100, 242, 97, 216, 47, 167, 66 } });

            migrationBuilder.CreateIndex(
                name: "IX_AccessUser_DashboardUserId_SiteTblId",
                table: "AccessUser",
                columns: new[] { "DashboardUserId", "SiteTblId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccessUser_SiteTblId",
                table: "AccessUser",
                column: "SiteTblId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessUser");

            migrationBuilder.DropColumn(
                name: "IsSuperAdmin",
                table: "DashboardUsers");

            migrationBuilder.UpdateData(
                table: "ApiUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 180, 90, 202, 21, 47, 137, 87, 124, 2, 134, 198, 156, 87, 147, 14, 52, 24, 128, 17, 92, 202, 113, 106, 203, 60, 231, 84, 120, 82, 175, 96, 44, 179, 65, 208, 90, 116, 57, 14, 72, 54, 240, 120, 237, 7, 94, 204, 226, 249, 154, 192, 180, 61, 38, 28, 230, 126, 180, 6, 4, 78, 23, 35, 211 }, new byte[] { 47, 199, 180, 87, 201, 189, 34, 86, 128, 24, 104, 213, 91, 17, 124, 190, 233, 78, 13, 110, 132, 76, 30, 25, 83, 22, 25, 91, 178, 243, 236, 61, 176, 6, 233, 146, 110, 172, 30, 51, 164, 79, 186, 220, 0, 223, 115, 143, 110, 18, 0, 29, 14, 145, 108, 250, 152, 89, 58, 101, 150, 252, 204, 68, 42, 91, 112, 60, 37, 106, 39, 205, 68, 104, 16, 99, 141, 77, 78, 96, 133, 148, 61, 199, 38, 18, 180, 207, 205, 66, 18, 207, 111, 162, 118, 101, 114, 84, 181, 49, 244, 135, 149, 199, 62, 90, 115, 242, 55, 29, 29, 124, 217, 246, 28, 7, 192, 66, 223, 80, 135, 195, 164, 138, 237, 239, 232, 21 } });

            migrationBuilder.UpdateData(
                table: "DashboardUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 180, 90, 202, 21, 47, 137, 87, 124, 2, 134, 198, 156, 87, 147, 14, 52, 24, 128, 17, 92, 202, 113, 106, 203, 60, 231, 84, 120, 82, 175, 96, 44, 179, 65, 208, 90, 116, 57, 14, 72, 54, 240, 120, 237, 7, 94, 204, 226, 249, 154, 192, 180, 61, 38, 28, 230, 126, 180, 6, 4, 78, 23, 35, 211 }, new byte[] { 47, 199, 180, 87, 201, 189, 34, 86, 128, 24, 104, 213, 91, 17, 124, 190, 233, 78, 13, 110, 132, 76, 30, 25, 83, 22, 25, 91, 178, 243, 236, 61, 176, 6, 233, 146, 110, 172, 30, 51, 164, 79, 186, 220, 0, 223, 115, 143, 110, 18, 0, 29, 14, 145, 108, 250, 152, 89, 58, 101, 150, 252, 204, 68, 42, 91, 112, 60, 37, 106, 39, 205, 68, 104, 16, 99, 141, 77, 78, 96, 133, 148, 61, 199, 38, 18, 180, 207, 205, 66, 18, 207, 111, 162, 118, 101, 114, 84, 181, 49, 244, 135, 149, 199, 62, 90, 115, 242, 55, 29, 29, 124, 217, 246, 28, 7, 192, 66, 223, 80, 135, 195, 164, 138, 237, 239, 232, 21 } });
        }
    }
}
