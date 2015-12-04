
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/01/2015 09:47:52
-- Generated from EDMX file: C:\Users\Administratör\Documents\Visual Studio 2015\Projects\ProgramingAssinment01.BardiaJedi\AirportSystem\Models\AirportDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [AirPortdb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Airports'
CREATE TABLE [dbo].[Airports] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [CityId] int  NOT NULL
);
GO

-- Creating table 'Airplanes'
CREATE TABLE [dbo].[Airplanes] (
    [RegNumber] nvarchar(max)  NOT NULL,
    [Capacity] smallint  NOT NULL,
    [Length] float  NOT NULL,
    [AirplaneTypesId] int  NOT NULL
);
GO

-- Creating table 'Citys'
CREATE TABLE [dbo].[Citys] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PilotSet'
CREATE TABLE [dbo].[PilotSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FName] nvarchar(max)  NOT NULL,
    [LName] nvarchar(max)  NOT NULL,
    [CityId] int  NOT NULL
);
GO

-- Creating table 'AirplaneTypes'
CREATE TABLE [dbo].[AirplaneTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Pilot_AirPlaneTypeSet'
CREATE TABLE [dbo].[Pilot_AirPlaneTypeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AirplaneTypesId] int  NOT NULL,
    [PilotId] int  NOT NULL
);
GO

-- Creating table 'ScheduleSet'
CREATE TABLE [dbo].[ScheduleSet] (
    [FlightNumber] int IDENTITY(1,1) NOT NULL,
    [FromAirportId] int  NOT NULL,
    [ToAirportId] int  NOT NULL,
    [AirplaneRegNumber] nvarchar(max)  NOT NULL,
    [PilotId] int  NOT NULL,
    [PilotIdCo] int  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Airports'
ALTER TABLE [dbo].[Airports]
ADD CONSTRAINT [PK_Airports]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [RegNumber] in table 'Airplanes'
ALTER TABLE [dbo].[Airplanes]
ADD CONSTRAINT [PK_Airplanes]
    PRIMARY KEY CLUSTERED ([RegNumber] ASC);
GO

-- Creating primary key on [Id] in table 'Citys'
ALTER TABLE [dbo].[Citys]
ADD CONSTRAINT [PK_Citys]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PilotSet'
ALTER TABLE [dbo].[PilotSet]
ADD CONSTRAINT [PK_PilotSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AirplaneTypes'
ALTER TABLE [dbo].[AirplaneTypes]
ADD CONSTRAINT [PK_AirplaneTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Pilot_AirPlaneTypeSet'
ALTER TABLE [dbo].[Pilot_AirPlaneTypeSet]
ADD CONSTRAINT [PK_Pilot_AirPlaneTypeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [FlightNumber] in table 'ScheduleSet'
ALTER TABLE [dbo].[ScheduleSet]
ADD CONSTRAINT [PK_ScheduleSet]
    PRIMARY KEY CLUSTERED ([FlightNumber] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [CityId] in table 'PilotSet'
ALTER TABLE [dbo].[PilotSet]
ADD CONSTRAINT [FK_CityPilot]
    FOREIGN KEY ([CityId])
    REFERENCES [dbo].[Citys]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CityPilot'
CREATE INDEX [IX_FK_CityPilot]
ON [dbo].[PilotSet]
    ([CityId]);
GO

-- Creating foreign key on [CityId] in table 'Airports'
ALTER TABLE [dbo].[Airports]
ADD CONSTRAINT [FK_AirportCity]
    FOREIGN KEY ([CityId])
    REFERENCES [dbo].[Citys]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AirportCity'
CREATE INDEX [IX_FK_AirportCity]
ON [dbo].[Airports]
    ([CityId]);
GO

-- Creating foreign key on [AirplaneTypesId] in table 'Airplanes'
ALTER TABLE [dbo].[Airplanes]
ADD CONSTRAINT [FK_AirplaneTypesAirplane]
    FOREIGN KEY ([AirplaneTypesId])
    REFERENCES [dbo].[AirplaneTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AirplaneTypesAirplane'
CREATE INDEX [IX_FK_AirplaneTypesAirplane]
ON [dbo].[Airplanes]
    ([AirplaneTypesId]);
GO

-- Creating foreign key on [AirplaneTypesId] in table 'Pilot_AirPlaneTypeSet'
ALTER TABLE [dbo].[Pilot_AirPlaneTypeSet]
ADD CONSTRAINT [FK_AirplaneTypesPilot_AirPlaneType]
    FOREIGN KEY ([AirplaneTypesId])
    REFERENCES [dbo].[AirplaneTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AirplaneTypesPilot_AirPlaneType'
CREATE INDEX [IX_FK_AirplaneTypesPilot_AirPlaneType]
ON [dbo].[Pilot_AirPlaneTypeSet]
    ([AirplaneTypesId]);
GO

-- Creating foreign key on [PilotId] in table 'Pilot_AirPlaneTypeSet'
ALTER TABLE [dbo].[Pilot_AirPlaneTypeSet]
ADD CONSTRAINT [FK_PilotPilot_AirPlaneType]
    FOREIGN KEY ([PilotId])
    REFERENCES [dbo].[PilotSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PilotPilot_AirPlaneType'
CREATE INDEX [IX_FK_PilotPilot_AirPlaneType]
ON [dbo].[Pilot_AirPlaneTypeSet]
    ([PilotId]);
GO

-- Creating foreign key on [FromAirportId] in table 'ScheduleSet'
ALTER TABLE [dbo].[ScheduleSet]
ADD CONSTRAINT [FK_ScheduleAirportFrom]
    FOREIGN KEY ([FromAirportId])
    REFERENCES [dbo].[Airports]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ScheduleAirportFrom'
CREATE INDEX [IX_FK_ScheduleAirportFrom]
ON [dbo].[ScheduleSet]
    ([FromAirportId]);
GO

-- Creating foreign key on [ToAirportId] in table 'ScheduleSet'
ALTER TABLE [dbo].[ScheduleSet]
ADD CONSTRAINT [FK_AirportSchedule]
    FOREIGN KEY ([ToAirportId])
    REFERENCES [dbo].[Airports]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AirportSchedule'
CREATE INDEX [IX_FK_AirportSchedule]
ON [dbo].[ScheduleSet]
    ([ToAirportId]);
GO

-- Creating foreign key on [AirplaneRegNumber] in table 'ScheduleSet'
ALTER TABLE [dbo].[ScheduleSet]
ADD CONSTRAINT [FK_AirplaneSchedule]
    FOREIGN KEY ([AirplaneRegNumber])
    REFERENCES [dbo].[Airplanes]
        ([RegNumber])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AirplaneSchedule'
CREATE INDEX [IX_FK_AirplaneSchedule]
ON [dbo].[ScheduleSet]
    ([AirplaneRegNumber]);
GO

-- Creating foreign key on [PilotId] in table 'ScheduleSet'
ALTER TABLE [dbo].[ScheduleSet]
ADD CONSTRAINT [FK_PilotSchedule]
    FOREIGN KEY ([PilotId])
    REFERENCES [dbo].[PilotSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PilotSchedule'
CREATE INDEX [IX_FK_PilotSchedule]
ON [dbo].[ScheduleSet]
    ([PilotId]);
GO

-- Creating foreign key on [PilotIdCo] in table 'ScheduleSet'
ALTER TABLE [dbo].[ScheduleSet]
ADD CONSTRAINT [FK_PilotSchedule1]
    FOREIGN KEY ([PilotIdCo])
    REFERENCES [dbo].[PilotSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PilotSchedule1'
CREATE INDEX [IX_FK_PilotSchedule1]
ON [dbo].[ScheduleSet]
    ([PilotIdCo]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------