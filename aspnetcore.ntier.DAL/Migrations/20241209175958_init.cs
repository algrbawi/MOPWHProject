using System;
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
                name: "Camera_TBL",
                columns: table => new
                {
                    CamID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    CamName = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CamIP = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CamPort = table.Column<int>(type: "int", nullable: true),
                    CamUsername = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CamPassword = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CamModel = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CamState = table.Column<bool>(type: "bit", nullable: true),
                    Site_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camera_TBL", x => x.CamID);
                });

            migrationBuilder.CreateTable(
                name: "COM_SETTING_TBL",
                columns: table => new
                {
                    COM_ID = table.Column<decimal>(type: "numeric(20,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COM_NAME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BPS = table.Column<int>(type: "int", nullable: true),
                    DB = table.Column<int>(type: "int", nullable: true),
                    PARITY = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SB = table.Column<int>(type: "int", nullable: true),
                    HDSH = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SStart = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SEND = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    SITE_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COM_SETTING_TBL_1", x => x.COM_ID);
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

            migrationBuilder.CreateTable(
                name: "Drivers_TBL",
                columns: table => new
                {
                    Driver_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    Driver_Code = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Driver_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Driver_State = table.Column<bool>(type: "bit", nullable: true),
                    Site_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers_TBL", x => x.Driver_ID);
                });

            migrationBuilder.CreateTable(
                name: "Nation_TBL",
                columns: table => new
                {
                    Nation_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    Nation_Code = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Nation_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Nation_State = table.Column<bool>(type: "bit", nullable: true),
                    Site_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nation_TBL", x => x.Nation_ID);
                });

            migrationBuilder.CreateTable(
                name: "Site_TBL",
                columns: table => new
                {
                    Site_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    Site_Code = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Site_Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Site_Location = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Site_Title = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Site_State = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site_TBL", x => x.Site_ID);
                });

            migrationBuilder.CreateTable(
                name: "Pictures_TBL",
                columns: table => new
                {
                    Pic_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pic_date = table.Column<DateOnly>(type: "date", nullable: true),
                    Pic_Time = table.Column<TimeOnly>(type: "time", nullable: true),
                    Pic_Camera = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Pic_State = table.Column<bool>(type: "bit", nullable: true),
                    Pic_Image = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Pic_Truck_ID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Site_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures_TBL", x => x.Pic_ID);
                    table.ForeignKey(
                        name: "FK_Pictures_TBL_Site_TBL",
                        column: x => x.Site_ID,
                        principalTable: "Site_TBL",
                        principalColumn: "Site_ID");
                });

            migrationBuilder.CreateTable(
                name: "Products_TBL",
                columns: table => new
                {
                    Product_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    Product_Code = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Product_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Product_Location = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Product_State = table.Column<bool>(type: "bit", nullable: true),
                    Site_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_TBL", x => x.Product_ID);
                    table.ForeignKey(
                        name: "FK_Products_TBL_Site_TBL",
                        column: x => x.Site_ID,
                        principalTable: "Site_TBL",
                        principalColumn: "Site_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Setting_TBL",
                columns: table => new
                {
                    ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Title = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    CPrinter = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    RPrinter = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Indecator = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Note = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    State = table.Column<bool>(type: "bit", nullable: true),
                    Site_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting_TBL", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Setting_TBL_Site_TBL",
                        column: x => x.Site_ID,
                        principalTable: "Site_TBL",
                        principalColumn: "Site_ID");
                });

            migrationBuilder.CreateTable(
                name: "Trucks_TBL",
                columns: table => new
                {
                    Truck_Num = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Truck_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    Truck_Code = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Truck_State = table.Column<bool>(type: "bit", nullable: true),
                    Site_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trucks_TBL", x => x.Truck_Num);
                    table.ForeignKey(
                        name: "FK_Trucks_TBL_Site_TBL",
                        column: x => x.Site_ID,
                        principalTable: "Site_TBL",
                        principalColumn: "Site_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users_TBL",
                columns: table => new
                {
                    User_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    User_Code = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    User_Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    User_Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    User_Type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    User_State = table.Column<bool>(type: "bit", nullable: true),
                    Site_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_TBL", x => x.User_ID);
                    table.ForeignKey(
                        name: "FK_Users_TBL_Site_TBL",
                        column: x => x.Site_ID,
                        principalTable: "Site_TBL",
                        principalColumn: "Site_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weight_Class_TBL",
                columns: table => new
                {
                    W_Class_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    W_Class_Code = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    W_Class_Name = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    W_Class_Axles = table.Column<int>(type: "int", nullable: true),
                    W_Class_Weight = table.Column<int>(type: "int", nullable: true),
                    W_Class_State = table.Column<bool>(type: "bit", nullable: true),
                    W_Class_Image = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Site_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weight_Class_TBL", x => x.W_Class_ID);
                    table.ForeignKey(
                        name: "FK_Weight_Class_TBL_Site_TBL",
                        column: x => x.Site_ID,
                        principalTable: "Site_TBL",
                        principalColumn: "Site_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weight_Ticket_TBL",
                columns: table => new
                {
                    W_Ticket_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    W_Ticket_Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    W_Ticket_Start = table.Column<int>(type: "int", nullable: true),
                    W_Ticket_End = table.Column<int>(type: "int", nullable: true),
                    W_Ticket_Price = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    W_Ticket_State = table.Column<bool>(type: "bit", nullable: true),
                    Site_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weight_Ticket_TBL", x => x.W_Ticket_ID);
                    table.ForeignKey(
                        name: "FK_Weight_Ticket_TBL_Site_TBL",
                        column: x => x.Site_ID,
                        principalTable: "Site_TBL",
                        principalColumn: "Site_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Weight_TBL",
                columns: table => new
                {
                    W_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    SEQ_NO = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    In_Date = table.Column<DateOnly>(type: "date", nullable: true),
                    In_Time = table.Column<TimeOnly>(type: "time", nullable: true),
                    W_Class_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Class_Weight = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Truck_Weight = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Diff_Weight = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Vio_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true, defaultValue: 0m),
                    Vio_Weight = table.Column<int>(type: "int", nullable: true, defaultValue: 0),
                    Truck_Num = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Nation_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Product_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Driver_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Printed = table.Column<bool>(type: "bit", nullable: true),
                    Transed = table.Column<bool>(type: "bit", nullable: true),
                    Weight_S = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Weight_Location = table.Column<bool>(type: "bit", nullable: true),
                    Weight_Note = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Weight_State = table.Column<bool>(type: "bit", nullable: true),
                    User_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Site_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weight_TBL", x => x.W_ID);
                    table.ForeignKey(
                        name: "FK_Weight_TBL_Drivers_TBL",
                        column: x => x.Driver_ID,
                        principalTable: "Drivers_TBL",
                        principalColumn: "Driver_ID");
                    table.ForeignKey(
                        name: "FK_Weight_TBL_Nation_TBL",
                        column: x => x.Nation_ID,
                        principalTable: "Nation_TBL",
                        principalColumn: "Nation_ID");
                    table.ForeignKey(
                        name: "FK_Weight_TBL_Trucks_TBL",
                        column: x => x.Truck_Num,
                        principalTable: "Trucks_TBL",
                        principalColumn: "Truck_Num");
                });

            migrationBuilder.CreateTable(
                name: "Log_TBL",
                columns: table => new
                {
                    Log_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    Log_Code = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Log_Name = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Log_Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Log_Time = table.Column<TimeOnly>(type: "time", nullable: true),
                    Log_Trans = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    User_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Site_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log_TBL", x => x.Log_ID);
                    table.ForeignKey(
                        name: "FK_Log_TBL_Site_TBL",
                        column: x => x.Site_ID,
                        principalTable: "Site_TBL",
                        principalColumn: "Site_ID");
                    table.ForeignKey(
                        name: "FK_Log_TBL_Users_TBL",
                        column: x => x.User_ID,
                        principalTable: "Users_TBL",
                        principalColumn: "User_ID");
                });

            migrationBuilder.InsertData(
                table: "ApiUsers",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt" },
                values: new object[] { 1, "admin@admin.com", new byte[] { 208, 107, 208, 69, 252, 12, 249, 77, 247, 139, 8, 120, 37, 236, 205, 101, 232, 125, 175, 76, 222, 78, 125, 135, 36, 101, 217, 12, 37, 56, 145, 81, 233, 180, 246, 56, 167, 223, 103, 67, 39, 81, 234, 210, 236, 124, 235, 75, 22, 53, 213, 142, 80, 125, 21, 153, 25, 183, 254, 209, 142, 221, 139, 50 }, new byte[] { 190, 153, 254, 250, 174, 226, 243, 54, 202, 221, 22, 66, 74, 106, 217, 24, 251, 193, 95, 3, 71, 220, 38, 48, 86, 155, 145, 195, 27, 80, 200, 127, 61, 159, 186, 82, 209, 112, 193, 48, 32, 106, 201, 79, 245, 160, 58, 149, 226, 126, 14, 148, 92, 19, 88, 9, 252, 155, 99, 148, 80, 158, 220, 54, 65, 155, 62, 27, 61, 182, 147, 69, 153, 210, 41, 138, 142, 183, 240, 172, 49, 161, 104, 101, 171, 19, 228, 20, 120, 81, 158, 105, 117, 243, 116, 112, 78, 190, 219, 218, 189, 51, 168, 126, 146, 191, 190, 29, 45, 217, 87, 18, 64, 11, 28, 26, 25, 83, 185, 65, 178, 39, 244, 71, 88, 67, 54, 147 } });

            migrationBuilder.InsertData(
                table: "DashboardUsers",
                columns: new[] { "Id", "Email", "Name", "PasswordHash", "PasswordSalt" },
                values: new object[] { 1, "admin@admin.com", "Admin", new byte[] { 208, 107, 208, 69, 252, 12, 249, 77, 247, 139, 8, 120, 37, 236, 205, 101, 232, 125, 175, 76, 222, 78, 125, 135, 36, 101, 217, 12, 37, 56, 145, 81, 233, 180, 246, 56, 167, 223, 103, 67, 39, 81, 234, 210, 236, 124, 235, 75, 22, 53, 213, 142, 80, 125, 21, 153, 25, 183, 254, 209, 142, 221, 139, 50 }, new byte[] { 190, 153, 254, 250, 174, 226, 243, 54, 202, 221, 22, 66, 74, 106, 217, 24, 251, 193, 95, 3, 71, 220, 38, 48, 86, 155, 145, 195, 27, 80, 200, 127, 61, 159, 186, 82, 209, 112, 193, 48, 32, 106, 201, 79, 245, 160, 58, 149, 226, 126, 14, 148, 92, 19, 88, 9, 252, 155, 99, 148, 80, 158, 220, 54, 65, 155, 62, 27, 61, 182, 147, 69, 153, 210, 41, 138, 142, 183, 240, 172, 49, 161, 104, 101, 171, 19, 228, 20, 120, 81, 158, 105, 117, 243, 116, 112, 78, 190, 219, 218, 189, 51, 168, 126, 146, 191, 190, 29, 45, 217, 87, 18, 64, 11, 28, 26, 25, 83, 185, 65, 178, 39, 244, 71, 88, 67, 54, 147 } });

            migrationBuilder.CreateIndex(
                name: "IX_Log_TBL_Site_ID",
                table: "Log_TBL",
                column: "Site_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Log_TBL_User_ID",
                table: "Log_TBL",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_TBL_Site_ID",
                table: "Pictures_TBL",
                column: "Site_ID");

            migrationBuilder.CreateIndex(
                name: "NonClusteredIndex-20241209-112232",
                table: "Pictures_TBL",
                column: "Pic_date");

            migrationBuilder.CreateIndex(
                name: "Pic_IDTruck_ID_INDEX",
                table: "Pictures_TBL",
                columns: new[] { "Pic_ID", "Pic_Truck_ID" },
                unique: true,
                filter: "[Pic_Truck_ID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TBL_Site_ID",
                table: "Products_TBL",
                column: "Site_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Setting_TBL_Site_ID",
                table: "Setting_TBL",
                column: "Site_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Trucks_TBL_Site_ID",
                table: "Trucks_TBL",
                column: "Site_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TBL_Site_ID",
                table: "Users_TBL",
                column: "Site_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Weight_Class_TBL_Site_ID",
                table: "Weight_Class_TBL",
                column: "Site_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Weight_TBL_Driver_ID",
                table: "Weight_TBL",
                column: "Driver_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Weight_TBL_Nation_ID",
                table: "Weight_TBL",
                column: "Nation_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Weight_TBL_Truck_Num",
                table: "Weight_TBL",
                column: "Truck_Num");

            migrationBuilder.CreateIndex(
                name: "IX_Weight_Ticket_TBL_Site_ID",
                table: "Weight_Ticket_TBL",
                column: "Site_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApiUsers");

            migrationBuilder.DropTable(
                name: "Camera_TBL");

            migrationBuilder.DropTable(
                name: "COM_SETTING_TBL");

            migrationBuilder.DropTable(
                name: "DashboardUsers");

            migrationBuilder.DropTable(
                name: "Log_TBL");

            migrationBuilder.DropTable(
                name: "Pictures_TBL");

            migrationBuilder.DropTable(
                name: "Products_TBL");

            migrationBuilder.DropTable(
                name: "Setting_TBL");

            migrationBuilder.DropTable(
                name: "Weight_Class_TBL");

            migrationBuilder.DropTable(
                name: "Weight_TBL");

            migrationBuilder.DropTable(
                name: "Weight_Ticket_TBL");

            migrationBuilder.DropTable(
                name: "Users_TBL");

            migrationBuilder.DropTable(
                name: "Drivers_TBL");

            migrationBuilder.DropTable(
                name: "Nation_TBL");

            migrationBuilder.DropTable(
                name: "Trucks_TBL");

            migrationBuilder.DropTable(
                name: "Site_TBL");
        }
    }
}
