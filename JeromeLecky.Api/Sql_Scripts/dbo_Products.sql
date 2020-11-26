CREATE TABLE [dbo].[Products] (
    [ProductId]     UNIQUEIDENTIFIER        NOT NULL,
    [SkuCode]       NVARCHAR(10)            NOT NULL,
    [Name]          NVARCHAR(100)           NOT NULL,
    [BasePrice]     DECIMAL(18, 2)          NOT NULL,
    [StockStatus]   INT                     NOT NULL,
    [StockQuantity] INT                     NOT NULL,
    [Category]      NVARCHAR(MAX)  	        NULL,
    PRIMARY KEY CLUSTERED ([ProductId] ASC)
);
