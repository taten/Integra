
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/10/2012 01:05:18
-- Generated from EDMX file: C:\Users\Martin\Documents\Visual Studio 2010\Projects\Obli_IS2\Dominio_Integra\Modelo.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Integra];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ProductoEstablecer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductoEstablecer];
GO
IF OBJECT_ID(N'[dbo].[ServicioEstablecer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServicioEstablecer];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ProductoEstablecer'
CREATE TABLE [dbo].[ProductoEstablecer] (
    [id] nvarchar(max)  NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [precio] nvarchar(max)  NOT NULL,
    [descuento] nvarchar(max)  NOT NULL,
    [impuesto] nvarchar(max)  NOT NULL,
    [descripcion_empaque] nvarchar(max)  NOT NULL,
    [peso] nvarchar(max)  NOT NULL,
    [color] nvarchar(max)  NOT NULL,
    [tamano] nvarchar(max)  NOT NULL,
    [oid] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'ServicioEstablecer'
CREATE TABLE [dbo].[ServicioEstablecer] (
    [id] nvarchar(max)  NOT NULL,
    [nombre] nvarchar(max)  NOT NULL,
    [descripcion] nvarchar(max)  NOT NULL,
    [precio] nvarchar(max)  NOT NULL,
    [descuento] nvarchar(max)  NOT NULL,
    [impuesto] nvarchar(max)  NOT NULL,
    [oid] int IDENTITY(1,1) NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [oid] in table 'ProductoEstablecer'
ALTER TABLE [dbo].[ProductoEstablecer]
ADD CONSTRAINT [PK_ProductoEstablecer]
    PRIMARY KEY CLUSTERED ([oid] ASC);
GO

-- Creating primary key on [oid] in table 'ServicioEstablecer'
ALTER TABLE [dbo].[ServicioEstablecer]
ADD CONSTRAINT [PK_ServicioEstablecer]
    PRIMARY KEY CLUSTERED ([oid] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------