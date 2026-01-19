BEGIN TRANSACTION;
GO

ALTER TABLE [DashboardUsers] ADD [FailedLoginAttempts] int NOT NULL DEFAULT 0;
GO

UPDATE [DashboardUsers] SET [FailedLoginAttempts] = 0
WHERE [Id] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260116112416_Add_FaileAttemptCounter_DashboardUsers', N'8.0.0');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Logs] (
    [Id] bigint NOT NULL IDENTITY,
    [RequestAt] datetime2 NOT NULL,
    [Body] nvarchar(max) NOT NULL,
    [Path] nvarchar(max) NOT NULL,
    [QueryString] nvarchar(max) NOT NULL,
    [Error] nvarchar(max) NOT NULL,
    [Schema] nvarchar(max) NOT NULL,
    [HttpMethod] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Logs] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260117113630_Add_Log_Table', N'8.0.0');
GO

COMMIT;
GO

