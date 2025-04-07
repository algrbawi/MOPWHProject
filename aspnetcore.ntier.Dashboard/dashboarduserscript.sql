BEGIN TRANSACTION;
GO

ALTER TABLE [DashboardUsers] ADD [IsActive] bit NOT NULL DEFAULT CAST(0 AS bit);
GO

ALTER TABLE [DashboardUsers] ADD [LastUpdatePassword] date NOT NULL DEFAULT '0001-01-01';
GO

UPDATE [DashboardUsers] SET [IsActive] = CAST(0 AS bit), [LastUpdatePassword] = '0001-01-01'
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250405104911_add_IsActive_and_LastPasswordUpdate_columns_on_dasgboardusertbl', N'8.0.0');
GO

COMMIT;
GO

