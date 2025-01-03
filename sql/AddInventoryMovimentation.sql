CREATE TABLE [InventoryMovimentation] (
    [Id] bigint NOT NULL IDENTITY,
    [CreateAt] datetime2 NOT NULL,
    [ProductId] bigint NOT NULL,
    [Quantity] float NOT NULL,
    [Inc] bit NOT NULL,
    CONSTRAINT [PK_InventoryMovimentation] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_InventoryMovimentation_Product_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Product] ([Id])
);

CREATE INDEX [IX_InventoryMovimentation_ProductId] ON [InventoryMovimentation] ([ProductId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250103140702_AddInventoryMovimentation', N'9.0.0');

COMMIT;
GO