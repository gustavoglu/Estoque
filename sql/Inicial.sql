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
CREATE TABLE [ProductType] (
    [Id] bigint NOT NULL IDENTITY,
    [Description] varchar(150) NOT NULL,
    [CreateAt] datetime2 NOT NULL,
    [UpdateAt] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_ProductType] PRIMARY KEY ([Id])
);

CREATE TABLE [Product] (
    [Id] bigint NOT NULL IDENTITY,
    [Description] varchar(150) NOT NULL,
    [Price] decimal(18,4) NOT NULL,
    [ProductTypeId] bigint NOT NULL,
    [CreateAt] datetime2 NOT NULL,
    [UpdateAt] datetime2 NULL,
    [IsDeleted] bit NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Product_ProductType_ProductTypeId] FOREIGN KEY ([ProductTypeId]) REFERENCES [ProductType] ([Id])
);

CREATE INDEX [IX_Product_ProductTypeId] ON [Product] ([ProductTypeId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250102014825_Inicial', N'9.0.0');

COMMIT;
GO

