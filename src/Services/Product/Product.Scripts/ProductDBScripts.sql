PRINT '--------START--------'

USE master;
GO

IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = 'ProductDb')
BEGIN
	PRINT 'DB: Create ProductDb database'
	CREATE DATABASE ProductDb;
END
GO

USE ProductDb;
GO
-- Products
IF OBJECT_ID('dbo.Products', 'U') IS NOT NULL
BEGIN
	PRINT 'TABLE: Drop Products table'
    DROP TABLE dbo.Products;
END

Print 'TABLE: Create Products table'
CREATE TABLE Products (
    [Id] [uniqueidentifier] NOT NULL DEFAULT (newid()),
    [Name] [nvarchar](100) NOT NULL,
    [Description] [text] NULL,
    [Price] [decimal](18, 2) NULL
)ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

PRINT  '--------END--------'
GO


PRINT  '--------SEED DATA--------'
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price]) VALUES (N'c1f75b84-e083-4b07-acba-4a485e6fba04', N'Apple', N'Fruit', CAST(300.05 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price]) VALUES (N'7dc79bde-4344-4219-af6b-bbfb67991cc0', N'Banana', N'Fruit', CAST(100.00 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price]) VALUES (N'959853a6-918f-4f2d-a927-c8937d62b722', N'Orange', N'Fruit', CAST(200.00 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price]) VALUES (N'53b0ead1-e1b6-4412-b55e-b9c9917dc074', N'Pineapple', N'Fruit', CAST(121.00 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price]) VALUES (N'03b00cf8-be54-41ad-a3cc-8e7fe4df8883', N'Watermelon', N'Fruit', CAST(500.00 AS Decimal(18, 2)))
INSERT [dbo].[Products] ([Id], [Name], [Description], [Price]) VALUES (N'bf836b6a-7f6f-4cf7-ba15-4bdec5feac42', N'Mango', N'Fruit', CAST(200.00 AS Decimal(18, 2)))
