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
                name: "DashboardUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    IsSuperAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Site_TBL",
                columns: table => new
                {
                    Site_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    Site_Code = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Site_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site_Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site_Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site_State = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Site_TBL", x => x.Site_ID);
                });

            migrationBuilder.CreateTable(
                name: "USER_P_Setting_TBL",
                columns: table => new
                {
                    USER_P_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    USER_P_Code = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    USER_P_Form = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USER_P_Name1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USER_P_Name2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USER_P_State = table.Column<bool>(type: "bit", nullable: true),
                    USER_P_Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_P_Setting_TBL", x => x.USER_P_ID);
                });

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

            migrationBuilder.CreateTable(
                name: "Camera_TBL",
                columns: table => new
                {
                    CamID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    CamName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CamIP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CamPort = table.Column<int>(type: "int", nullable: true),
                    CamUsername = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CamPassword = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CamModel = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CamState = table.Column<bool>(type: "bit", nullable: true),
                    Site_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camera_TBL", x => x.CamID);
                    table.ForeignKey(
                        name: "FK_Camera_TBL_Site_TBL",
                        column: x => x.Site_ID,
                        principalTable: "Site_TBL",
                        principalColumn: "Site_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COM_SCREEN_SETTING",
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
                    table.PrimaryKey("PK_COM_SCREEN_SETTING", x => x.COM_ID);
                    table.ForeignKey(
                        name: "FK_COM_SCREEN_SETTING_Site_TBL",
                        column: x => x.SITE_ID,
                        principalTable: "Site_TBL",
                        principalColumn: "Site_ID");
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
                    table.ForeignKey(
                        name: "FK_COM_SETTING_TBL_Site_TBL",
                        column: x => x.SITE_ID,
                        principalTable: "Site_TBL",
                        principalColumn: "Site_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drivers_TBL",
                columns: table => new
                {
                    Driver_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    Driver_Code = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Driver_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Driver_State = table.Column<bool>(type: "bit", nullable: true),
                    Site_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers_TBL", x => x.Driver_ID);
                    table.ForeignKey(
                        name: "FK_Drivers_TBL_Site_TBL",
                        column: x => x.Site_ID,
                        principalTable: "Site_TBL",
                        principalColumn: "Site_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Nation_TBL",
                columns: table => new
                {
                    Nation_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    Nation_Code = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Nation_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Nation_State = table.Column<bool>(type: "bit", nullable: true),
                    Site_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nation_TBL", x => x.Nation_ID);
                    table.ForeignKey(
                        name: "FK_Nation_TBL_Site_TBL",
                        column: x => x.Site_ID,
                        principalTable: "Site_TBL",
                        principalColumn: "Site_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pictures_TBL",
                columns: table => new
                {
                    Pic_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    Pic_date = table.Column<DateOnly>(type: "date", nullable: true),
                    Pic_Time = table.Column<TimeOnly>(type: "time", nullable: true),
                    Pic_Camera = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pic_State = table.Column<bool>(type: "bit", nullable: true),
                    Pic_Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pic_Truck_ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                    Product_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Product_Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPrinter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RPrinter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Indecator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Truck_Num = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
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
                    User_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    User_Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    User_Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
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
                    W_Class_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    W_Class_Axles = table.Column<int>(type: "int", nullable: true),
                    W_Class_Weight = table.Column<int>(type: "int", nullable: true),
                    W_Class_State = table.Column<bool>(type: "bit", nullable: true),
                    W_Class_Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    W_Ticket_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Log_TBL",
                columns: table => new
                {
                    Log_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    Log_Code = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Log_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Log_Date = table.Column<DateOnly>(type: "date", nullable: true),
                    Log_Time = table.Column<TimeOnly>(type: "time", nullable: true),
                    Log_Trans = table.Column<string>(type: "nvarchar(max)", nullable: true),
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

            migrationBuilder.CreateTable(
                name: "Users_Per_TBL",
                columns: table => new
                {
                    UP_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: false),
                    UP_Code = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    UP_State = table.Column<bool>(type: "bit", nullable: true),
                    UP_Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USER_P_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    User_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Site_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_Per_TBL", x => x.UP_ID);
                    table.ForeignKey(
                        name: "FK_Users_Per_TBL_Site_TBL",
                        column: x => x.Site_ID,
                        principalTable: "Site_TBL",
                        principalColumn: "Site_ID");
                    table.ForeignKey(
                        name: "FK_Users_Per_TBL_USER_P_Setting_TBL",
                        column: x => x.USER_P_ID,
                        principalTable: "USER_P_Setting_TBL",
                        principalColumn: "USER_P_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Per_TBL_Users_TBL",
                        column: x => x.User_ID,
                        principalTable: "Users_TBL",
                        principalColumn: "User_ID",
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
                    Truck_Num = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Nation_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Product_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Driver_ID = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    Printed = table.Column<bool>(type: "bit", nullable: true),
                    Transed = table.Column<bool>(type: "bit", nullable: true),
                    Weight_S = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight_Location = table.Column<bool>(type: "bit", nullable: true),
                    Weight_Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                        name: "FK_Weight_TBL_Products_TBL",
                        column: x => x.Product_ID,
                        principalTable: "Products_TBL",
                        principalColumn: "Product_ID");
                    table.ForeignKey(
                        name: "FK_Weight_TBL_Site_TBL",
                        column: x => x.Site_ID,
                        principalTable: "Site_TBL",
                        principalColumn: "Site_ID");
                    table.ForeignKey(
                        name: "FK_Weight_TBL_Trucks_TBL",
                        column: x => x.Truck_Num,
                        principalTable: "Trucks_TBL",
                        principalColumn: "Truck_Num");
                    table.ForeignKey(
                        name: "FK_Weight_TBL_Users_TBL",
                        column: x => x.User_ID,
                        principalTable: "Users_TBL",
                        principalColumn: "User_ID");
                    table.ForeignKey(
                        name: "FK_Weight_TBL_Weight_Class_TBL",
                        column: x => x.W_Class_ID,
                        principalTable: "Weight_Class_TBL",
                        principalColumn: "W_Class_ID");
                });

            migrationBuilder.InsertData(
                table: "ApiUsers",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt" },
                values: new object[] { 1, "admin@admin.com", new byte[] { 104, 136, 143, 19, 91, 5, 225, 182, 216, 68, 5, 115, 218, 150, 94, 159, 191, 141, 248, 163, 232, 71, 30, 153, 214, 80, 47, 192, 8, 145, 71, 249, 190, 24, 27, 7, 106, 166, 118, 135, 165, 169, 143, 163, 31, 23, 152, 100, 79, 110, 228, 225, 240, 16, 200, 173, 29, 142, 211, 253, 255, 82, 16, 97 }, new byte[] { 218, 41, 250, 3, 4, 72, 102, 113, 5, 134, 173, 68, 162, 218, 93, 198, 22, 180, 85, 173, 60, 242, 199, 254, 97, 8, 94, 144, 125, 214, 128, 39, 177, 255, 224, 218, 108, 38, 245, 243, 208, 203, 91, 11, 188, 249, 129, 161, 190, 87, 63, 83, 182, 112, 60, 6, 67, 66, 212, 55, 15, 25, 215, 50, 151, 219, 194, 22, 135, 232, 14, 178, 85, 175, 251, 202, 48, 67, 113, 113, 244, 107, 166, 193, 218, 172, 218, 137, 186, 116, 223, 232, 123, 148, 173, 121, 208, 147, 24, 133, 241, 42, 170, 40, 235, 98, 222, 132, 241, 72, 80, 43, 36, 132, 98, 218, 150, 169, 10, 230, 247, 28, 52, 138, 249, 206, 233, 59 } });

            migrationBuilder.InsertData(
                table: "DashboardUsers",
                columns: new[] { "Id", "Email", "IsSuperAdmin", "Name", "PasswordHash", "PasswordSalt" },
                values: new object[] { 1, "admin@admin.com", true, "Admin", new byte[] { 104, 136, 143, 19, 91, 5, 225, 182, 216, 68, 5, 115, 218, 150, 94, 159, 191, 141, 248, 163, 232, 71, 30, 153, 214, 80, 47, 192, 8, 145, 71, 249, 190, 24, 27, 7, 106, 166, 118, 135, 165, 169, 143, 163, 31, 23, 152, 100, 79, 110, 228, 225, 240, 16, 200, 173, 29, 142, 211, 253, 255, 82, 16, 97 }, new byte[] { 218, 41, 250, 3, 4, 72, 102, 113, 5, 134, 173, 68, 162, 218, 93, 198, 22, 180, 85, 173, 60, 242, 199, 254, 97, 8, 94, 144, 125, 214, 128, 39, 177, 255, 224, 218, 108, 38, 245, 243, 208, 203, 91, 11, 188, 249, 129, 161, 190, 87, 63, 83, 182, 112, 60, 6, 67, 66, 212, 55, 15, 25, 215, 50, 151, 219, 194, 22, 135, 232, 14, 178, 85, 175, 251, 202, 48, 67, 113, 113, 244, 107, 166, 193, 218, 172, 218, 137, 186, 116, 223, 232, 123, 148, 173, 121, 208, 147, 24, 133, 241, 42, 170, 40, 235, 98, 222, 132, 241, 72, 80, 43, 36, 132, 98, 218, 150, 169, 10, 230, 247, 28, 52, 138, 249, 206, 233, 59 } });

            migrationBuilder.CreateIndex(
                name: "IX_AccessUser_DashboardUserId_SiteTblId",
                table: "AccessUser",
                columns: new[] { "DashboardUserId", "SiteTblId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AccessUser_SiteTblId",
                table: "AccessUser",
                column: "SiteTblId");

            migrationBuilder.CreateIndex(
                name: "IX_Camera_TBL_Site_ID",
                table: "Camera_TBL",
                column: "Site_ID");

            migrationBuilder.CreateIndex(
                name: "IX_COM_SCREEN_SETTING_SITE_ID",
                table: "COM_SCREEN_SETTING",
                column: "SITE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_COM_SETTING_TBL_SITE_ID",
                table: "COM_SETTING_TBL",
                column: "SITE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_TBL_Site_ID",
                table: "Drivers_TBL",
                column: "Site_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Log_TBL_Site_ID",
                table: "Log_TBL",
                column: "Site_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Log_TBL_User_ID",
                table: "Log_TBL",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Nation_TBL_Site_ID",
                table: "Nation_TBL",
                column: "Site_ID");

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
                name: "IX_Users_Per_TBL_Site_ID",
                table: "Users_Per_TBL",
                column: "Site_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Per_TBL_User_ID",
                table: "Users_Per_TBL",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Per_TBL_USER_P_ID",
                table: "Users_Per_TBL",
                column: "USER_P_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TBL_Site_ID",
                table: "Users_TBL",
                column: "Site_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Weight_Class_TBL_Site_ID",
                table: "Weight_Class_TBL",
                column: "Site_ID");

            migrationBuilder.CreateIndex(
                name: "IN_DATE_INDEX",
                table: "Weight_TBL",
                column: "In_Date");

            migrationBuilder.CreateIndex(
                name: "IX_Weight_TBL_Driver_ID",
                table: "Weight_TBL",
                column: "Driver_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Weight_TBL_Nation_ID",
                table: "Weight_TBL",
                column: "Nation_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Weight_TBL_Product_ID",
                table: "Weight_TBL",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Weight_TBL_Truck_Num",
                table: "Weight_TBL",
                column: "Truck_Num");

            migrationBuilder.CreateIndex(
                name: "IX_Weight_TBL_User_ID",
                table: "Weight_TBL",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Weight_TBL_W_Class_ID",
                table: "Weight_TBL",
                column: "W_Class_ID");

            migrationBuilder.CreateIndex(
                name: "SITE_ID_INDEX",
                table: "Weight_TBL",
                column: "Site_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Weight_Ticket_TBL_Site_ID",
                table: "Weight_Ticket_TBL",
                column: "Site_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessUser");

            migrationBuilder.DropTable(
                name: "ApiUsers");

            migrationBuilder.DropTable(
                name: "Camera_TBL");

            migrationBuilder.DropTable(
                name: "COM_SCREEN_SETTING");

            migrationBuilder.DropTable(
                name: "COM_SETTING_TBL");

            migrationBuilder.DropTable(
                name: "Log_TBL");

            migrationBuilder.DropTable(
                name: "Pictures_TBL");

            migrationBuilder.DropTable(
                name: "Setting_TBL");

            migrationBuilder.DropTable(
                name: "Users_Per_TBL");

            migrationBuilder.DropTable(
                name: "Weight_TBL");

            migrationBuilder.DropTable(
                name: "Weight_Ticket_TBL");

            migrationBuilder.DropTable(
                name: "DashboardUsers");

            migrationBuilder.DropTable(
                name: "USER_P_Setting_TBL");

            migrationBuilder.DropTable(
                name: "Drivers_TBL");

            migrationBuilder.DropTable(
                name: "Nation_TBL");

            migrationBuilder.DropTable(
                name: "Products_TBL");

            migrationBuilder.DropTable(
                name: "Trucks_TBL");

            migrationBuilder.DropTable(
                name: "Users_TBL");

            migrationBuilder.DropTable(
                name: "Weight_Class_TBL");

            migrationBuilder.DropTable(
                name: "Site_TBL");
        }
    }
}
