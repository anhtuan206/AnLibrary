
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/18/2025 10:30:52
-- Generated from EDMX file: D:\Visual Studio App\AnLibrary\AnLibrary\Model\AnLibraryDb.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AnLibrary];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CategoryBook]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Books] DROP CONSTRAINT [FK_CategoryBook];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts];
GO
IF OBJECT_ID(N'[dbo].[Books]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Books];
GO
IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [Fullname] nvarchar(max)  NULL,
    [IdNumber] nvarchar(max)  NULL,
    [Address] nvarchar(max)  NULL,
    [Birthday] datetime  NULL,
    [isActive] bit  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Books'
CREATE TABLE [dbo].[Books] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BookName] nvarchar(max)  NOT NULL,
    [Author] nvarchar(max)  NULL,
    [Publisher] nvarchar(max)  NULL,
    [PublishYear] int  NULL,
    [Description] nvarchar(max)  NULL,
    [isActive] bit  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [ChangedBy] nvarchar(max)  NOT NULL,
    [ChangedDate] datetime  NOT NULL,
    [CategoryId] int  NULL,
    [Category_Id] int  NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CategoryCode] nvarchar(max)  NOT NULL,
    [Categoryname] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ChangedBy] nvarchar(max)  NOT NULL,
    [ChangedDate] datetime  NOT NULL
);
GO

-- Creating table 'Customers'
CREATE TABLE [dbo].[Customers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CustomerName] nvarchar(max)  NOT NULL,
    [Birthday] nvarchar(max)  NOT NULL,
    [Mobile] nvarchar(max)  NOT NULL,
    [IdentityNumber] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [CreatedDate] nvarchar(max)  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [ChangedDate] datetime  NOT NULL,
    [ChangedBy] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CustomerName] nvarchar(max)  NOT NULL,
    [Birthday] datetime  NOT NULL,
    [Mobile] nvarchar(max)  NOT NULL,
    [IdentityNumber] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [CreatedDate] nvarchar(max)  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [ChangedDate] datetime  NOT NULL,
    [ChangedBy] nvarchar(max)  NOT NULL,
    [LeaseOrder] bit  NOT NULL,
    [ReturnOrder] bit  NOT NULL,
    [ImportOrder] bit  NOT NULL,
    [Customer_Id] int  NULL
);
GO

-- Creating table 'OrderItems'
CREATE TABLE [dbo].[OrderItems] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BookName] nvarchar(max)  NOT NULL,
    [Author] nvarchar(max)  NULL,
    [Publisher] nvarchar(max)  NULL,
    [PublishYear] int  NULL,
    [Order_Id] int  NOT NULL,
    [Book_Id] int  NOT NULL
);
GO

-- Creating table 'WareHouses'
CREATE TABLE [dbo].[WareHouses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BookName] nvarchar(max)  NOT NULL,
    [TotalQty] nvarchar(max)  NOT NULL,
    [AvailableQty] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [ChangedBy] nvarchar(max)  NOT NULL,
    [ChangedDate] datetime  NOT NULL,
    [Book_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [PK_Books]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Customers'
ALTER TABLE [dbo].[Customers]
ADD CONSTRAINT [PK_Customers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderItems'
ALTER TABLE [dbo].[OrderItems]
ADD CONSTRAINT [PK_OrderItems]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WareHouses'
ALTER TABLE [dbo].[WareHouses]
ADD CONSTRAINT [PK_WareHouses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Category_Id] in table 'Books'
ALTER TABLE [dbo].[Books]
ADD CONSTRAINT [FK_CategoryBook]
    FOREIGN KEY ([Category_Id])
    REFERENCES [dbo].[Categories]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryBook'
CREATE INDEX [IX_FK_CategoryBook]
ON [dbo].[Books]
    ([Category_Id]);
GO

-- Creating foreign key on [Customer_Id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_CustomerOrder]
    FOREIGN KEY ([Customer_Id])
    REFERENCES [dbo].[Customers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CustomerOrder'
CREATE INDEX [IX_FK_CustomerOrder]
ON [dbo].[Orders]
    ([Customer_Id]);
GO

-- Creating foreign key on [Order_Id] in table 'OrderItems'
ALTER TABLE [dbo].[OrderItems]
ADD CONSTRAINT [FK_OrderOrderItem]
    FOREIGN KEY ([Order_Id])
    REFERENCES [dbo].[Orders]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrderOrderItem'
CREATE INDEX [IX_FK_OrderOrderItem]
ON [dbo].[OrderItems]
    ([Order_Id]);
GO

-- Creating foreign key on [Book_Id] in table 'OrderItems'
ALTER TABLE [dbo].[OrderItems]
ADD CONSTRAINT [FK_BookOrderItem]
    FOREIGN KEY ([Book_Id])
    REFERENCES [dbo].[Books]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookOrderItem'
CREATE INDEX [IX_FK_BookOrderItem]
ON [dbo].[OrderItems]
    ([Book_Id]);
GO

-- Creating foreign key on [Book_Id] in table 'WareHouses'
ALTER TABLE [dbo].[WareHouses]
ADD CONSTRAINT [FK_BookWareHouse]
    FOREIGN KEY ([Book_Id])
    REFERENCES [dbo].[Books]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BookWareHouse'
CREATE INDEX [IX_FK_BookWareHouse]
ON [dbo].[WareHouses]
    ([Book_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------