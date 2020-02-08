
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/27/2019 17:04:46
-- Generated from EDMX file: E:\Visual Studio 2019\Source\Repos\TPTutorials\ConsoleApp01\ModelFirstDemoDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ModelFirstDemoDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_StudentEnrolment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Enrolments] DROP CONSTRAINT [FK_StudentEnrolment];
GO
IF OBJECT_ID(N'[dbo].[FK_CourseEnrolment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Enrolments] DROP CONSTRAINT [FK_CourseEnrolment];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Students]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Students];
GO
IF OBJECT_ID(N'[dbo].[Courses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Courses];
GO
IF OBJECT_ID(N'[dbo].[Enrolments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Enrolments];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Students'
CREATE TABLE [dbo].[Students] (
    [StudentId] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [EnrolmentDate] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Courses'
CREATE TABLE [dbo].[Courses] (
    [CourseId] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Credits] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Enrolments'
CREATE TABLE [dbo].[Enrolments] (
    [EnrolmentId] int IDENTITY(1,1) NOT NULL,
    [CourseId] int  NOT NULL,
    [StudentId] int  NOT NULL,
    [Grade] nvarchar(max)  NOT NULL,
    [StudentStudentId] int  NOT NULL,
    [StudentStudentId1] int  NOT NULL,
    [CourseCourseId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [StudentId] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [PK_Students]
    PRIMARY KEY CLUSTERED ([StudentId] ASC);
GO

-- Creating primary key on [CourseId] in table 'Courses'
ALTER TABLE [dbo].[Courses]
ADD CONSTRAINT [PK_Courses]
    PRIMARY KEY CLUSTERED ([CourseId] ASC);
GO

-- Creating primary key on [EnrolmentId] in table 'Enrolments'
ALTER TABLE [dbo].[Enrolments]
ADD CONSTRAINT [PK_Enrolments]
    PRIMARY KEY CLUSTERED ([EnrolmentId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [StudentStudentId1] in table 'Enrolments'
ALTER TABLE [dbo].[Enrolments]
ADD CONSTRAINT [FK_StudentEnrolment]
    FOREIGN KEY ([StudentStudentId1])
    REFERENCES [dbo].[Students]
        ([StudentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentEnrolment'
CREATE INDEX [IX_FK_StudentEnrolment]
ON [dbo].[Enrolments]
    ([StudentStudentId1]);
GO

-- Creating foreign key on [CourseCourseId] in table 'Enrolments'
ALTER TABLE [dbo].[Enrolments]
ADD CONSTRAINT [FK_CourseEnrolment]
    FOREIGN KEY ([CourseCourseId])
    REFERENCES [dbo].[Courses]
        ([CourseId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CourseEnrolment'
CREATE INDEX [IX_FK_CourseEnrolment]
ON [dbo].[Enrolments]
    ([CourseCourseId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------