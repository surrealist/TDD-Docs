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

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220702085233_Init')
BEGIN
    CREATE TABLE [Orders] (
        [OrderId] nvarchar(20) NOT NULL,
        [Date] datetimeoffset NOT NULL,
        [CustomerName] nvarchar(200) NOT NULL,
        CONSTRAINT [PK_Orders] PRIMARY KEY ([OrderId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220702085233_Init')
BEGIN
    CREATE TABLE [OrderDetails] (
        [OrderId] nvarchar(20) NOT NULL,
        [LineId] int NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [SalePrice] decimal(18,2) NOT NULL,
        [Quantity] int NOT NULL,
        [VatPercent] real NOT NULL,
        CONSTRAINT [PK_OrderDetails] PRIMARY KEY ([OrderId], [LineId]),
        CONSTRAINT [FK_OrderDetails_Orders_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [Orders] ([OrderId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220702085233_Init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220702085233_Init', N'6.0.6');
END;
GO

COMMIT;
GO

