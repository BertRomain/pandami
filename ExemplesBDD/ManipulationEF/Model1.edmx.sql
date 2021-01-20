
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/14/2021 15:04:39
-- Generated from EDMX file: C:\Users\sdupuy\source\repos\EQL2020\Cecharpe-Repository\ExemplesBDD\ManipulationEF\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [bddEQL];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[client]', 'U') IS NOT NULL
    DROP TABLE [dbo].[client];
GO
IF OBJECT_ID(N'[dbo].[region]', 'U') IS NOT NULL
    DROP TABLE [dbo].[region];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'client'
CREATE TABLE [dbo].[client] (
    [noclient] int  NOT NULL,
    [nom] nvarchar(50)  NULL,
    [adresse] nvarchar(50)  NULL,
    [noregion] int  NULL,
    [IdTelephone] int  NOT NULL
);
GO

-- Creating table 'region'
CREATE TABLE [dbo].[region] (
    [idregion] int  NOT NULL,
    [nomregion] nvarchar(50)  NULL
);
GO

-- Creating table 'TelephoneSet'
CREATE TABLE [dbo].[TelephoneSet] (
    [IdTelephone] int IDENTITY(1,1) NOT NULL,
    [NumeroTel] nvarchar(max)  NOT NULL,
    [TypeNumero] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [noclient] in table 'client'
ALTER TABLE [dbo].[client]
ADD CONSTRAINT [PK_client]
    PRIMARY KEY CLUSTERED ([noclient] ASC);
GO

-- Creating primary key on [idregion] in table 'region'
ALTER TABLE [dbo].[region]
ADD CONSTRAINT [PK_region]
    PRIMARY KEY CLUSTERED ([idregion] ASC);
GO

-- Creating primary key on [IdTelephone] in table 'TelephoneSet'
ALTER TABLE [dbo].[TelephoneSet]
ADD CONSTRAINT [PK_TelephoneSet]
    PRIMARY KEY CLUSTERED ([IdTelephone] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------