
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/15/2020 09:31:57
-- Generated from EDMX file: E:\Visual Studio 2019\Source\Repos\MicrosoftTutorials\NavigatingData\pbTestManyToMany_DBF\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Projects];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Projects_Solutions]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Projects] DROP CONSTRAINT [FK_Projects_Solutions];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectsRefs_Projects]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectsRefs] DROP CONSTRAINT [FK_ProjectsRefs_Projects];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjKeyw_Projects]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectsKeywords] DROP CONSTRAINT [FK_ProjKeyw_Projects];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Keywords]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Keywords];
GO
IF OBJECT_ID(N'[dbo].[Projects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Projects];
GO
IF OBJECT_ID(N'[dbo].[ProjectsKeywords]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectsKeywords];
GO
IF OBJECT_ID(N'[dbo].[ProjectsRefs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectsRefs];
GO
IF OBJECT_ID(N'[dbo].[Refs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Refs];
GO
IF OBJECT_ID(N'[dbo].[Solutions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Solutions];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Keywords'
CREATE TABLE [dbo].[Keywords] (
    [KeywordID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'Projects'
CREATE TABLE [dbo].[Projects] (
    [ProjectID] int IDENTITY(1,1) NOT NULL,
    [SolutionID] int  NULL,
    [Name] nvarchar(200)  NOT NULL,
    [Location] nvarchar(500)  NOT NULL
);
GO

-- Creating table 'ProjectsKeywords'
CREATE TABLE [dbo].[ProjectsKeywords] (
    [ProjectID] int  NOT NULL,
    [KeywordID] int  NOT NULL
);
GO

-- Creating table 'ProjectsRefs'
CREATE TABLE [dbo].[ProjectsRefs] (
    [ProjectID] int  NOT NULL,
    [RefID] int  NOT NULL
);
GO

-- Creating table 'Refs'
CREATE TABLE [dbo].[Refs] (
    [RefID] int IDENTITY(1,1) NOT NULL,
    [Url] nvarchar(400)  NOT NULL,
    [Description] nvarchar(200)  NOT NULL
);
GO

-- Creating table 'Solutions'
CREATE TABLE [dbo].[Solutions] (
    [SolutionID] int  NOT NULL,
    [Name] nvarchar(200)  NOT NULL,
    [Location] nvarchar(500)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [KeywordID] in table 'Keywords'
ALTER TABLE [dbo].[Keywords]
ADD CONSTRAINT [PK_Keywords]
    PRIMARY KEY CLUSTERED ([KeywordID] ASC);
GO

-- Creating primary key on [ProjectID] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [PK_Projects]
    PRIMARY KEY CLUSTERED ([ProjectID] ASC);
GO

-- Creating primary key on [ProjectID], [KeywordID] in table 'ProjectsKeywords'
ALTER TABLE [dbo].[ProjectsKeywords]
ADD CONSTRAINT [PK_ProjectsKeywords]
    PRIMARY KEY CLUSTERED ([ProjectID], [KeywordID] ASC);
GO

-- Creating primary key on [ProjectID], [RefID] in table 'ProjectsRefs'
ALTER TABLE [dbo].[ProjectsRefs]
ADD CONSTRAINT [PK_ProjectsRefs]
    PRIMARY KEY CLUSTERED ([ProjectID], [RefID] ASC);
GO

-- Creating primary key on [RefID] in table 'Refs'
ALTER TABLE [dbo].[Refs]
ADD CONSTRAINT [PK_Refs]
    PRIMARY KEY CLUSTERED ([RefID] ASC);
GO

-- Creating primary key on [SolutionID] in table 'Solutions'
ALTER TABLE [dbo].[Solutions]
ADD CONSTRAINT [PK_Solutions]
    PRIMARY KEY CLUSTERED ([SolutionID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SolutionID] in table 'Projects'
ALTER TABLE [dbo].[Projects]
ADD CONSTRAINT [FK_Projects_Solutions]
    FOREIGN KEY ([SolutionID])
    REFERENCES [dbo].[Solutions]
        ([SolutionID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Projects_Solutions'
CREATE INDEX [IX_FK_Projects_Solutions]
ON [dbo].[Projects]
    ([SolutionID]);
GO

-- Creating foreign key on [ProjectID] in table 'ProjectsRefs'
ALTER TABLE [dbo].[ProjectsRefs]
ADD CONSTRAINT [FK_ProjectsRefs_Projects]
    FOREIGN KEY ([ProjectID])
    REFERENCES [dbo].[Projects]
        ([ProjectID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ProjectID] in table 'ProjectsKeywords'
ALTER TABLE [dbo].[ProjectsKeywords]
ADD CONSTRAINT [FK_ProjKeyw_Projects]
    FOREIGN KEY ([ProjectID])
    REFERENCES [dbo].[Projects]
        ([ProjectID])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------