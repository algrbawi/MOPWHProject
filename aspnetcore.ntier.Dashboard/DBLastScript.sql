IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [ApiUsers] (
    [Id] int NOT NULL IDENTITY,
    [Email] nvarchar(max) NOT NULL,
    [PasswordHash] varbinary(max) NOT NULL,
    [PasswordSalt] varbinary(max) NOT NULL,
    CONSTRAINT [PK_ApiUsers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [DashboardUsers] (
    [Id] int NOT NULL IDENTITY,
    [Email] nvarchar(max) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    [PasswordHash] varbinary(max) NOT NULL,
    [PasswordSalt] varbinary(max) NOT NULL,
    [IsSuperAdmin] bit NOT NULL,
    CONSTRAINT [PK_DashboardUsers] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Site_TBL] (
    [Site_ID] numeric(18,0) NOT NULL,
    [Site_Code] numeric(18,0) NULL,
    [Site_Name] nvarchar(max) NULL,
    [Site_Location] nvarchar(max) NULL,
    [Site_Title] nvarchar(max) NULL,
    [Site_State] bit NULL,
    CONSTRAINT [PK_Site_TBL] PRIMARY KEY ([Site_ID])
);
GO

CREATE TABLE [USER_P_Setting_TBL] (
    [USER_P_ID] numeric(18,0) NOT NULL,
    [USER_P_Code] numeric(18,0) NULL,
    [USER_P_Form] nvarchar(max) NULL,
    [USER_P_Name1] nvarchar(max) NULL,
    [USER_P_Name2] nvarchar(max) NULL,
    [USER_P_State] bit NULL,
    [USER_P_Note] nvarchar(max) NULL,
    [Site_ID] numeric(18,0) NULL,
    CONSTRAINT [PK_USER_P_Setting_TBL] PRIMARY KEY ([USER_P_ID])
);
GO

CREATE TABLE [AccessUser] (
    [Id] int NOT NULL IDENTITY,
    [DashboardUserId] int NOT NULL,
    [SiteTblId] numeric(18,0) NOT NULL,
    CONSTRAINT [PK_AccessUser] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AccessUser_DashboardUsers_DashboardUserId] FOREIGN KEY ([DashboardUserId]) REFERENCES [DashboardUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AccessUser_Site_TBL_SiteTblId] FOREIGN KEY ([SiteTblId]) REFERENCES [Site_TBL] ([Site_ID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Camera_TBL] (
    [CamID] numeric(18,0) NOT NULL,
    [CamName] nvarchar(max) NULL,
    [CamIP] nvarchar(max) NULL,
    [CamPort] int NULL,
    [CamUsername] nvarchar(50) NULL,
    [CamPassword] nvarchar(50) NULL,
    [CamModel] nvarchar(50) NULL,
    [CamState] bit NULL,
    [Site_ID] numeric(18,0) NULL,
    CONSTRAINT [PK_Camera_TBL] PRIMARY KEY ([CamID]),
    CONSTRAINT [FK_Camera_TBL_Site_TBL] FOREIGN KEY ([Site_ID]) REFERENCES [Site_TBL] ([Site_ID]) ON DELETE CASCADE
);
GO

CREATE TABLE [COM_SCREEN_SETTING] (
    [COM_ID] numeric(20,0) NOT NULL IDENTITY,
    [COM_NAME] nvarchar(50) NULL,
    [BPS] int NULL,
    [DB] int NULL,
    [PARITY] nvarchar(50) NULL,
    [SB] int NULL,
    [HDSH] nvarchar(50) NULL,
    [SStart] nvarchar(50) NULL,
    [SEND] nvarchar(50) NULL,
    [SITE_ID] numeric(18,0) NOT NULL,
    CONSTRAINT [PK_COM_SCREEN_SETTING] PRIMARY KEY ([COM_ID]),
    CONSTRAINT [FK_COM_SCREEN_SETTING_Site_TBL] FOREIGN KEY ([SITE_ID]) REFERENCES [Site_TBL] ([Site_ID])
);
GO

CREATE TABLE [COM_SETTING_TBL] (
    [COM_ID] numeric(20,0) NOT NULL IDENTITY,
    [COM_NAME] nvarchar(50) NULL,
    [BPS] int NULL,
    [DB] int NULL,
    [PARITY] nvarchar(50) NULL,
    [SB] int NULL,
    [HDSH] nvarchar(50) NULL,
    [SStart] nvarchar(50) NULL,
    [SEND] nvarchar(50) NULL,
    [SITE_ID] numeric(18,0) NOT NULL,
    CONSTRAINT [PK_COM_SETTING_TBL_1] PRIMARY KEY ([COM_ID]),
    CONSTRAINT [FK_COM_SETTING_TBL_Site_TBL] FOREIGN KEY ([SITE_ID]) REFERENCES [Site_TBL] ([Site_ID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Drivers_TBL] (
    [Driver_ID] numeric(18,0) NOT NULL,
    [Driver_Code] numeric(18,0) NULL,
    [Driver_Name] nvarchar(200) NULL,
    [Driver_State] bit NULL,
    [Site_ID] numeric(18,0) NULL,
    CONSTRAINT [PK_Drivers_TBL] PRIMARY KEY ([Driver_ID]),
    CONSTRAINT [FK_Drivers_TBL_Site_TBL] FOREIGN KEY ([Site_ID]) REFERENCES [Site_TBL] ([Site_ID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Nation_TBL] (
    [Nation_ID] numeric(18,0) NOT NULL,
    [Nation_Code] numeric(18,0) NULL,
    [Nation_Name] nvarchar(200) NULL,
    [Nation_State] bit NULL,
    [Site_ID] numeric(18,0) NULL,
    CONSTRAINT [PK_Nation_TBL] PRIMARY KEY ([Nation_ID]),
    CONSTRAINT [FK_Nation_TBL_Site_TBL] FOREIGN KEY ([Site_ID]) REFERENCES [Site_TBL] ([Site_ID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Pictures_TBL] (
    [Pic_ID] numeric(18,0) NOT NULL,
    [Pic_date] date NULL,
    [Pic_Time] time NULL,
    [Pic_Camera] nvarchar(max) NULL,
    [Pic_State] bit NULL,
    [Pic_Image] nvarchar(max) NULL,
    [Pic_Truck_ID] nvarchar(50) NULL,
    [Site_ID] numeric(18,0) NULL,
    CONSTRAINT [PK_Pictures_TBL] PRIMARY KEY ([Pic_ID]),
    CONSTRAINT [FK_Pictures_TBL_Site_TBL] FOREIGN KEY ([Site_ID]) REFERENCES [Site_TBL] ([Site_ID])
);
GO

CREATE TABLE [Products_TBL] (
    [Product_ID] numeric(18,0) NOT NULL,
    [Product_Code] numeric(18,0) NULL,
    [Product_Name] nvarchar(200) NULL,
    [Product_Location] nvarchar(max) NULL,
    [Product_State] bit NULL,
    [Site_ID] numeric(18,0) NULL,
    CONSTRAINT [PK_Products_TBL] PRIMARY KEY ([Product_ID]),
    CONSTRAINT [FK_Products_TBL_Site_TBL] FOREIGN KEY ([Site_ID]) REFERENCES [Site_TBL] ([Site_ID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Setting_TBL] (
    [ID] numeric(18,0) NOT NULL,
    [Name] nvarchar(max) NULL,
    [Title] nvarchar(max) NULL,
    [CPrinter] nvarchar(max) NULL,
    [RPrinter] nvarchar(max) NULL,
    [Indecator] nvarchar(max) NULL,
    [Note] nvarchar(max) NULL,
    [State] bit NULL,
    [Site_ID] numeric(18,0) NULL,
    CONSTRAINT [PK_Setting_TBL] PRIMARY KEY ([ID]),
    CONSTRAINT [FK_Setting_TBL_Site_TBL] FOREIGN KEY ([Site_ID]) REFERENCES [Site_TBL] ([Site_ID])
);
GO

CREATE TABLE [Trucks_TBL] (
    [Truck_Num] nvarchar(200) NOT NULL,
    [Truck_ID] numeric(18,0) NOT NULL,
    [Truck_Code] numeric(18,0) NULL,
    [Truck_State] bit NULL,
    [Site_ID] numeric(18,0) NULL,
    CONSTRAINT [PK_Trucks_TBL] PRIMARY KEY ([Truck_Num]),
    CONSTRAINT [FK_Trucks_TBL_Site_TBL] FOREIGN KEY ([Site_ID]) REFERENCES [Site_TBL] ([Site_ID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Users_TBL] (
    [User_ID] numeric(18,0) NOT NULL,
    [User_Code] numeric(18,0) NULL,
    [User_Name] nvarchar(50) NULL,
    [User_Password] nvarchar(50) NULL,
    [User_Type] nvarchar(50) NULL,
    [User_State] bit NULL,
    [Site_ID] numeric(18,0) NULL,
    CONSTRAINT [PK_Users_TBL] PRIMARY KEY ([User_ID]),
    CONSTRAINT [FK_Users_TBL_Site_TBL] FOREIGN KEY ([Site_ID]) REFERENCES [Site_TBL] ([Site_ID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Weight_Class_TBL] (
    [W_Class_ID] numeric(18,0) NOT NULL,
    [W_Class_Code] numeric(18,0) NULL,
    [W_Class_Name] nvarchar(200) NULL,
    [W_Class_Axles] int NULL,
    [W_Class_Weight] int NULL,
    [W_Class_State] bit NULL,
    [W_Class_Image] nvarchar(max) NULL,
    [Site_ID] numeric(18,0) NULL,
    CONSTRAINT [PK_Weight_Class_TBL] PRIMARY KEY ([W_Class_ID]),
    CONSTRAINT [FK_Weight_Class_TBL_Site_TBL] FOREIGN KEY ([Site_ID]) REFERENCES [Site_TBL] ([Site_ID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Weight_Ticket_TBL] (
    [W_Ticket_ID] numeric(18,0) NOT NULL,
    [W_Ticket_Name] nvarchar(max) NULL,
    [W_Ticket_Start] int NULL,
    [W_Ticket_End] int NULL,
    [W_Ticket_Price] decimal(18,0) NULL,
    [W_Ticket_State] bit NULL,
    [Site_ID] numeric(18,0) NULL,
    CONSTRAINT [PK_Weight_Ticket_TBL] PRIMARY KEY ([W_Ticket_ID]),
    CONSTRAINT [FK_Weight_Ticket_TBL_Site_TBL] FOREIGN KEY ([Site_ID]) REFERENCES [Site_TBL] ([Site_ID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Log_TBL] (
    [Log_ID] numeric(18,0) NOT NULL,
    [Log_Code] numeric(18,0) NULL,
    [Log_Name] nvarchar(max) NULL,
    [Log_Date] date NULL,
    [Log_Time] time NULL,
    [Log_Trans] nvarchar(max) NULL,
    [User_ID] numeric(18,0) NULL,
    [Site_ID] numeric(18,0) NULL,
    CONSTRAINT [PK_Log_TBL] PRIMARY KEY ([Log_ID]),
    CONSTRAINT [FK_Log_TBL_Site_TBL] FOREIGN KEY ([Site_ID]) REFERENCES [Site_TBL] ([Site_ID]),
    CONSTRAINT [FK_Log_TBL_Users_TBL] FOREIGN KEY ([User_ID]) REFERENCES [Users_TBL] ([User_ID])
);
GO

CREATE TABLE [Users_Per_TBL] (
    [UP_ID] numeric(18,0) NOT NULL,
    [UP_Code] numeric(18,0) NULL,
    [UP_State] bit NULL,
    [UP_Note] nvarchar(max) NULL,
    [USER_P_ID] numeric(18,0) NULL,
    [User_ID] numeric(18,0) NULL,
    [Site_ID] numeric(18,0) NULL,
    CONSTRAINT [PK_Users_Per_TBL] PRIMARY KEY ([UP_ID]),
    CONSTRAINT [FK_Users_Per_TBL_Site_TBL] FOREIGN KEY ([Site_ID]) REFERENCES [Site_TBL] ([Site_ID]),
    CONSTRAINT [FK_Users_Per_TBL_USER_P_Setting_TBL] FOREIGN KEY ([USER_P_ID]) REFERENCES [USER_P_Setting_TBL] ([USER_P_ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Users_Per_TBL_Users_TBL] FOREIGN KEY ([User_ID]) REFERENCES [Users_TBL] ([User_ID]) ON DELETE CASCADE
);
GO

CREATE TABLE [Weight_TBL] (
    [W_ID] numeric(18,0) NOT NULL,
    [SEQ_NO] numeric(18,0) NULL,
    [In_Date] date NULL,
    [In_Time] time NULL,
    [W_Class_ID] numeric(18,0) NULL,
    [Class_Weight] int NULL DEFAULT 0,
    [Truck_Weight] int NULL DEFAULT 0,
    [Diff_Weight] int NULL DEFAULT 0,
    [Vio_Price] decimal(18,2) NULL DEFAULT 0.0,
    [Vio_Weight] int NULL DEFAULT 0,
    [Truck_Num] nvarchar(200) NULL,
    [Nation_ID] numeric(18,0) NULL,
    [Product_ID] numeric(18,0) NULL,
    [Driver_ID] numeric(18,0) NULL,
    [Printed] bit NULL,
    [Transed] bit NULL,
    [Weight_S] nvarchar(max) NULL,
    [Weight_Location] bit NULL,
    [Weight_Note] nvarchar(max) NULL,
    [Weight_State] bit NULL,
    [User_ID] numeric(18,0) NULL,
    [Site_ID] numeric(18,0) NULL,
    CONSTRAINT [PK_Weight_TBL] PRIMARY KEY ([W_ID]),
    CONSTRAINT [FK_Weight_TBL_Drivers_TBL] FOREIGN KEY ([Driver_ID]) REFERENCES [Drivers_TBL] ([Driver_ID]),
    CONSTRAINT [FK_Weight_TBL_Nation_TBL] FOREIGN KEY ([Nation_ID]) REFERENCES [Nation_TBL] ([Nation_ID]),
    CONSTRAINT [FK_Weight_TBL_Products_TBL] FOREIGN KEY ([Product_ID]) REFERENCES [Products_TBL] ([Product_ID]),
    CONSTRAINT [FK_Weight_TBL_Site_TBL] FOREIGN KEY ([Site_ID]) REFERENCES [Site_TBL] ([Site_ID]),
    CONSTRAINT [FK_Weight_TBL_Trucks_TBL] FOREIGN KEY ([Truck_Num]) REFERENCES [Trucks_TBL] ([Truck_Num]),
    CONSTRAINT [FK_Weight_TBL_Users_TBL] FOREIGN KEY ([User_ID]) REFERENCES [Users_TBL] ([User_ID]),
    CONSTRAINT [FK_Weight_TBL_Weight_Class_TBL] FOREIGN KEY ([W_Class_ID]) REFERENCES [Weight_Class_TBL] ([W_Class_ID])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'PasswordHash', N'PasswordSalt') AND [object_id] = OBJECT_ID(N'[ApiUsers]'))
    SET IDENTITY_INSERT [ApiUsers] ON;
INSERT INTO [ApiUsers] ([Id], [Email], [PasswordHash], [PasswordSalt])
VALUES (1, N'admin@admin.com', 0x68888F135B05E1B6D8440573DA965E9FBF8DF8A3E8471E99D6502FC0089147F9BE181B076AA67687A5A98FA31F1798644F6EE4E1F010C8AD1D8ED3FDFF521061, 0xDA29FA03044866710586AD44A2DA5DC616B455AD3CF2C7FE61085E907DD68027B1FFE0DA6C26F5F3D0CB5B0BBCF981A1BE573F53B6703C064342D4370F19D73297DBC21687E80EB255AFFBCA30437171F46BA6C1DAACDA89BA74DFE87B94AD79D0931885F12AAA28EB62DE84F148502B248462DA96A90AE6F71C348AF9CEE93B);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'PasswordHash', N'PasswordSalt') AND [object_id] = OBJECT_ID(N'[ApiUsers]'))
    SET IDENTITY_INSERT [ApiUsers] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'IsSuperAdmin', N'Name', N'PasswordHash', N'PasswordSalt') AND [object_id] = OBJECT_ID(N'[DashboardUsers]'))
    SET IDENTITY_INSERT [DashboardUsers] ON;
INSERT INTO [DashboardUsers] ([Id], [Email], [IsSuperAdmin], [Name], [PasswordHash], [PasswordSalt])
VALUES (1, N'admin@admin.com', CAST(1 AS bit), N'Admin', 0x68888F135B05E1B6D8440573DA965E9FBF8DF8A3E8471E99D6502FC0089147F9BE181B076AA67687A5A98FA31F1798644F6EE4E1F010C8AD1D8ED3FDFF521061, 0xDA29FA03044866710586AD44A2DA5DC616B455AD3CF2C7FE61085E907DD68027B1FFE0DA6C26F5F3D0CB5B0BBCF981A1BE573F53B6703C064342D4370F19D73297DBC21687E80EB255AFFBCA30437171F46BA6C1DAACDA89BA74DFE87B94AD79D0931885F12AAA28EB62DE84F148502B248462DA96A90AE6F71C348AF9CEE93B);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Email', N'IsSuperAdmin', N'Name', N'PasswordHash', N'PasswordSalt') AND [object_id] = OBJECT_ID(N'[DashboardUsers]'))
    SET IDENTITY_INSERT [DashboardUsers] OFF;
GO

CREATE UNIQUE INDEX [IX_AccessUser_DashboardUserId_SiteTblId] ON [AccessUser] ([DashboardUserId], [SiteTblId]);
GO

CREATE INDEX [IX_AccessUser_SiteTblId] ON [AccessUser] ([SiteTblId]);
GO

CREATE INDEX [IX_Camera_TBL_Site_ID] ON [Camera_TBL] ([Site_ID]);
GO

CREATE INDEX [IX_COM_SCREEN_SETTING_SITE_ID] ON [COM_SCREEN_SETTING] ([SITE_ID]);
GO

CREATE INDEX [IX_COM_SETTING_TBL_SITE_ID] ON [COM_SETTING_TBL] ([SITE_ID]);
GO

CREATE INDEX [IX_Drivers_TBL_Site_ID] ON [Drivers_TBL] ([Site_ID]);
GO

CREATE INDEX [IX_Log_TBL_Site_ID] ON [Log_TBL] ([Site_ID]);
GO

CREATE INDEX [IX_Log_TBL_User_ID] ON [Log_TBL] ([User_ID]);
GO

CREATE INDEX [IX_Nation_TBL_Site_ID] ON [Nation_TBL] ([Site_ID]);
GO

CREATE INDEX [IX_Pictures_TBL_Site_ID] ON [Pictures_TBL] ([Site_ID]);
GO

CREATE INDEX [NonClusteredIndex-20241209-112232] ON [Pictures_TBL] ([Pic_date]);
GO

CREATE UNIQUE INDEX [Pic_IDTruck_ID_INDEX] ON [Pictures_TBL] ([Pic_ID], [Pic_Truck_ID]) WHERE [Pic_Truck_ID] IS NOT NULL;
GO

CREATE INDEX [IX_Products_TBL_Site_ID] ON [Products_TBL] ([Site_ID]);
GO

CREATE INDEX [IX_Setting_TBL_Site_ID] ON [Setting_TBL] ([Site_ID]);
GO

CREATE INDEX [IX_Trucks_TBL_Site_ID] ON [Trucks_TBL] ([Site_ID]);
GO

CREATE INDEX [IX_Users_Per_TBL_Site_ID] ON [Users_Per_TBL] ([Site_ID]);
GO

CREATE INDEX [IX_Users_Per_TBL_User_ID] ON [Users_Per_TBL] ([User_ID]);
GO

CREATE INDEX [IX_Users_Per_TBL_USER_P_ID] ON [Users_Per_TBL] ([USER_P_ID]);
GO

CREATE INDEX [IX_Users_TBL_Site_ID] ON [Users_TBL] ([Site_ID]);
GO

CREATE INDEX [IX_Weight_Class_TBL_Site_ID] ON [Weight_Class_TBL] ([Site_ID]);
GO

CREATE INDEX [IN_DATE_INDEX] ON [Weight_TBL] ([In_Date]);
GO

CREATE INDEX [IX_Weight_TBL_Driver_ID] ON [Weight_TBL] ([Driver_ID]);
GO

CREATE INDEX [IX_Weight_TBL_Nation_ID] ON [Weight_TBL] ([Nation_ID]);
GO

CREATE INDEX [IX_Weight_TBL_Product_ID] ON [Weight_TBL] ([Product_ID]);
GO

CREATE INDEX [IX_Weight_TBL_Truck_Num] ON [Weight_TBL] ([Truck_Num]);
GO

CREATE INDEX [IX_Weight_TBL_User_ID] ON [Weight_TBL] ([User_ID]);
GO

CREATE INDEX [IX_Weight_TBL_W_Class_ID] ON [Weight_TBL] ([W_Class_ID]);
GO

CREATE INDEX [SITE_ID_INDEX] ON [Weight_TBL] ([Site_ID]);
GO

CREATE INDEX [IX_Weight_Ticket_TBL_Site_ID] ON [Weight_Ticket_TBL] ([Site_ID]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250124221426_init', N'8.0.0');
GO

COMMIT;
GO

