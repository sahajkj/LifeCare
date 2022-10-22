
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/22/2022 22:53:52
-- Generated from EDMX file: C:\Users\sahaj\source\repos\FIT5032_Assignment_LifeCare\FIT5032_Assignment_LifeCare\FIT5032_Assignment_LifeCare\Models\LifecareDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [aspnet-src-20221018065628];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_DoctorAppointment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Appointments] DROP CONSTRAINT [FK_DoctorAppointment];
GO
IF OBJECT_ID(N'[dbo].[FK_PatientAppointment]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Appointments] DROP CONSTRAINT [FK_PatientAppointment];
GO
IF OBJECT_ID(N'[dbo].[FK_PatientTestBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TestBookings] DROP CONSTRAINT [FK_PatientTestBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_DoctorRating]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ratings] DROP CONSTRAINT [FK_DoctorRating];
GO
IF OBJECT_ID(N'[dbo].[FK_TestTestBooking]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TestBookings] DROP CONSTRAINT [FK_TestTestBooking];
GO
IF OBJECT_ID(N'[dbo].[FK_PatientRating]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ratings] DROP CONSTRAINT [FK_PatientRating];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Tests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tests];
GO
IF OBJECT_ID(N'[dbo].[Patients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Patients];
GO
IF OBJECT_ID(N'[dbo].[Doctors]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Doctors];
GO
IF OBJECT_ID(N'[dbo].[Appointments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Appointments];
GO
IF OBJECT_ID(N'[dbo].[TestBookings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TestBookings];
GO
IF OBJECT_ID(N'[dbo].[Ratings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ratings];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Tests'
CREATE TABLE [dbo].[Tests] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Price] float  NOT NULL,
    [Type] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Patients'
CREATE TABLE [dbo].[Patients] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Gender] nvarchar(max)  NOT NULL,
    [DateOfBirth] datetime  NOT NULL,
    [Latitude] nvarchar(max)  NOT NULL,
    [Longitude] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Doctors'
CREATE TABLE [dbo].[Doctors] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Speciality] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Appointments'
CREATE TABLE [dbo].[Appointments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DateTime] datetime  NOT NULL,
    [Status] bit  NOT NULL,
    [Price] float  NOT NULL,
    [DoctorId] int  NOT NULL,
    [PatientId] int  NULL,
    [Text] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TestBookings'
CREATE TABLE [dbo].[TestBookings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DateTime] datetime  NOT NULL,
    [Status] bit  NOT NULL,
    [PatientId] int  NULL,
    [TestId] int  NOT NULL
);
GO

-- Creating table 'Ratings'
CREATE TABLE [dbo].[Ratings] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Value] int  NOT NULL,
    [DoctorId] int  NOT NULL,
    [PatientId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Tests'
ALTER TABLE [dbo].[Tests]
ADD CONSTRAINT [PK_Tests]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Patients'
ALTER TABLE [dbo].[Patients]
ADD CONSTRAINT [PK_Patients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Doctors'
ALTER TABLE [dbo].[Doctors]
ADD CONSTRAINT [PK_Doctors]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Appointments'
ALTER TABLE [dbo].[Appointments]
ADD CONSTRAINT [PK_Appointments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TestBookings'
ALTER TABLE [dbo].[TestBookings]
ADD CONSTRAINT [PK_TestBookings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Ratings'
ALTER TABLE [dbo].[Ratings]
ADD CONSTRAINT [PK_Ratings]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [DoctorId] in table 'Appointments'
ALTER TABLE [dbo].[Appointments]
ADD CONSTRAINT [FK_DoctorAppointment]
    FOREIGN KEY ([DoctorId])
    REFERENCES [dbo].[Doctors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoctorAppointment'
CREATE INDEX [IX_FK_DoctorAppointment]
ON [dbo].[Appointments]
    ([DoctorId]);
GO

-- Creating foreign key on [PatientId] in table 'Appointments'
ALTER TABLE [dbo].[Appointments]
ADD CONSTRAINT [FK_PatientAppointment]
    FOREIGN KEY ([PatientId])
    REFERENCES [dbo].[Patients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PatientAppointment'
CREATE INDEX [IX_FK_PatientAppointment]
ON [dbo].[Appointments]
    ([PatientId]);
GO

-- Creating foreign key on [PatientId] in table 'TestBookings'
ALTER TABLE [dbo].[TestBookings]
ADD CONSTRAINT [FK_PatientTestBooking]
    FOREIGN KEY ([PatientId])
    REFERENCES [dbo].[Patients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PatientTestBooking'
CREATE INDEX [IX_FK_PatientTestBooking]
ON [dbo].[TestBookings]
    ([PatientId]);
GO

-- Creating foreign key on [DoctorId] in table 'Ratings'
ALTER TABLE [dbo].[Ratings]
ADD CONSTRAINT [FK_DoctorRating]
    FOREIGN KEY ([DoctorId])
    REFERENCES [dbo].[Doctors]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_DoctorRating'
CREATE INDEX [IX_FK_DoctorRating]
ON [dbo].[Ratings]
    ([DoctorId]);
GO

-- Creating foreign key on [TestId] in table 'TestBookings'
ALTER TABLE [dbo].[TestBookings]
ADD CONSTRAINT [FK_TestTestBooking]
    FOREIGN KEY ([TestId])
    REFERENCES [dbo].[Tests]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TestTestBooking'
CREATE INDEX [IX_FK_TestTestBooking]
ON [dbo].[TestBookings]
    ([TestId]);
GO

-- Creating foreign key on [PatientId] in table 'Ratings'
ALTER TABLE [dbo].[Ratings]
ADD CONSTRAINT [FK_PatientRating]
    FOREIGN KEY ([PatientId])
    REFERENCES [dbo].[Patients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PatientRating'
CREATE INDEX [IX_FK_PatientRating]
ON [dbo].[Ratings]
    ([PatientId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------