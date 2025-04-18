
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/17/2025 21:30:15
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
    [Category_Id] int  NOT NULL
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

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------