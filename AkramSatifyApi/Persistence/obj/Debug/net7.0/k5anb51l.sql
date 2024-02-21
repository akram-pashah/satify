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

CREATE TABLE [Owner] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(128) NOT NULL,
    [DateOfBirth] datetime2 NOT NULL,
    [Address] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Owner] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Account] (
    [Id] uniqueidentifier NOT NULL,
    [DateCreated] datetime2 NOT NULL,
    [AccountType] nvarchar(50) NOT NULL,
    [OwnerId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Account] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Account_Owner_OwnerId] FOREIGN KEY ([OwnerId]) REFERENCES [Owner] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Account_OwnerId] ON [Account] ([OwnerId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20231214114957_InitialMigration', N'7.0.2');
GO

COMMIT;
GO

