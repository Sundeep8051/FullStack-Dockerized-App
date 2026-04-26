CREATE DATABASE ProductsDb
GO

USE [ProductsDb]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](500) NOT NULL,
	[category] [nvarchar](500) NOT NULL,
	[price] [decimal](18, 9) NULL,
	[quantity] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO Product (Name, Category, Price, Quantity)
VALUES
('IPhone 17', 'Electronics', 100, 2),
('Samsung S26', 'Electronics', 90, 3)

