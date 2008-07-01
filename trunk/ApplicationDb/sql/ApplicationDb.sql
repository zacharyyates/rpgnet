SET  ARITHABORT, CONCAT_NULL_YIELDS_NULL, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, QUOTED_IDENTIFIER ON 
SET  NUMERIC_ROUNDABORT OFF
GO
:setvar DatabaseName "ApplicationDb"
:setvar PrimaryFilePhysicalName "C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\ApplicationDb.mdf"
:setvar PrimaryLogFilePhysicalName "C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\ApplicationDb_log.ldf"

USE [master]

GO

:on error exit

IF  (DB_ID(N'$(DatabaseName)') IS NOT NULL
    AND DATABASEPROPERTYEX(N'$(DatabaseName)','Status') <> N'ONLINE')
BEGIN
    RAISERROR(N'The state of the target database, %s, is not set to ONLINE. To deploy to this database, its state must be set to ONLINE.', 16, 127,N'$(DatabaseName)') WITH NOWAIT
    RETURN
END
GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL)
BEGIN
    IF ((SELECT CAST(value AS nvarchar(128))
	    FROM 
		    [$(DatabaseName)]..fn_listextendedproperty('microsoft_database_tools_deploystamp', null, null, null, null, null, null )) 
	    = CAST(N'f965f691-14fd-41c2-b024-e099e0a06e76' AS nvarchar(128)))
    BEGIN
	    RAISERROR(N'Deployment has been skipped because the script has already been deployed to the target server.', 16 ,100) WITH NOWAIT
	    RETURN
    END
END
GO


:on error exit

CREATE DATABASE [$(DatabaseName)] ON ( NAME = N'PrimaryFileName', FILENAME = N'$(PrimaryFilePhysicalName)') LOG ON ( NAME = N'PrimaryLogFileName', FILENAME = N'$(PrimaryLogFilePhysicalName)') COLLATE SQL_Latin1_General_CP1_CS_AS 

GO

:on error resume
     
EXEC sp_dbcmptlevel N'$(DatabaseName)', 90

GO

IF EXISTS (SELECT 1 FROM [sys].[databases] WHERE [name] = N'$(DatabaseName)') 
    ALTER DATABASE [$(DatabaseName)] SET  
	ALLOW_SNAPSHOT_ISOLATION OFF
GO

IF EXISTS (SELECT 1 FROM [sys].[databases] WHERE [name] = N'$(DatabaseName)') 
    ALTER DATABASE [$(DatabaseName)] SET  
	READ_COMMITTED_SNAPSHOT OFF
GO

IF EXISTS (SELECT 1 FROM [sys].[databases] WHERE [name] = N'$(DatabaseName)') 
    ALTER DATABASE [$(DatabaseName)] SET  
	MULTI_USER,
	CURSOR_CLOSE_ON_COMMIT OFF,
	CURSOR_DEFAULT LOCAL,
	AUTO_CLOSE OFF,
	AUTO_CREATE_STATISTICS ON,
	AUTO_SHRINK OFF,
	AUTO_UPDATE_STATISTICS ON,
	AUTO_UPDATE_STATISTICS_ASYNC ON,
	ANSI_NULL_DEFAULT ON,
	ANSI_NULLS ON,
	ANSI_PADDING ON,
	ANSI_WARNINGS ON,
	ARITHABORT ON,
	CONCAT_NULL_YIELDS_NULL ON,
	NUMERIC_ROUNDABORT OFF,
	QUOTED_IDENTIFIER ON,
	RECURSIVE_TRIGGERS OFF,
	RECOVERY FULL,
	PAGE_VERIFY NONE,
	DISABLE_BROKER,
	PARAMETERIZATION SIMPLE
	WITH ROLLBACK IMMEDIATE
GO

IF IS_SRVROLEMEMBER ('sysadmin') = 1
BEGIN

IF EXISTS (SELECT 1 FROM [sys].[databases] WHERE [name] = N'$(DatabaseName)') 
    EXEC sp_executesql N'
    ALTER DATABASE [$(DatabaseName)] SET  
	DB_CHAINING OFF,
	TRUSTWORTHY OFF'

END
ELSE
BEGIN
    RAISERROR(N'Unable to modify the database settings for DB_CHAINING or TRUSTWORTHY. You must be a SysAdmin in order to apply these settings.',0,1)
END

GO

USE [$(DatabaseName)]

GO
/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script	
 Use SQLCMD syntax to include a file into the pre-deployment script			
 Example:      :r .\filename.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/








GO

:on error exit

:on error resume
GO
PRINT N'Creating [dbo].[Deity]'
GO
CREATE TABLE [dbo].[Deity]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_Deity] on [dbo].[Deity]'
GO
ALTER TABLE [dbo].[Deity] ADD CONSTRAINT [PK_Deity] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[Actor]'
GO
CREATE TABLE [dbo].[Actor]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[PlayerFK] [int] NULL,
[CharacterClassFK] [int] NULL,
[RaceFK] [int] NULL,
[DeityFK] [int] NULL,
[GroupFK] [int] NULL,
[Name] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Strength] [int] NULL,
[Constitution] [int] NULL,
[Dexterity] [int] NULL,
[Intelligence] [int] NULL,
[Wisdom] [int] NULL,
[Charisma] [int] NULL,
[Wealth] [decimal] (18, 0) NULL,
[Experience] [int] NULL,
[Age] [int] NULL,
[Gender] [tinyint] NULL,
[Height] [int] NULL,
[Weight] [int] NULL,
[Alignment] [tinyint] NULL,
[Milestones] [int] NULL,
[PersonalityTraits] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[MannerismsAndAppearance] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Background] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[OtherEquipment] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_Character] on [dbo].[Actor]'
GO
ALTER TABLE [dbo].[Actor] ADD CONSTRAINT [PK_Character] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[ActorFeat]'
GO
CREATE TABLE [dbo].[ActorFeat]
(
[ActorIdFk] [int] NOT NULL,
[FeatIdFk] [int] NOT NULL,
[Target] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_ActorFeat] on [dbo].[ActorFeat]'
GO
ALTER TABLE [dbo].[ActorFeat] ADD CONSTRAINT [PK_ActorFeat] PRIMARY KEY CLUSTERED  ([ActorIdFk], [FeatIdFk]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[ActorPower]'
GO
CREATE TABLE [dbo].[ActorPower]
(
[ActorIdFk] [int] NOT NULL,
[PowerIdFk] [int] NOT NULL
) ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_ActorPower] on [dbo].[ActorPower]'
GO
ALTER TABLE [dbo].[ActorPower] ADD CONSTRAINT [PK_ActorPower] PRIMARY KEY CLUSTERED  ([ActorIdFk], [PowerIdFk]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[Player]'
GO
CREATE TABLE [dbo].[Player]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_Player] on [dbo].[Player]'
GO
ALTER TABLE [dbo].[Player] ADD CONSTRAINT [PK_Player] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[ActorSkill]'
GO
CREATE TABLE [dbo].[ActorSkill]
(
[ActorIdFk] [int] NOT NULL,
[SkillIdFk] [int] NOT NULL,
[Trained] [int] NULL
) ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_ActorSkill] on [dbo].[ActorSkill]'
GO
ALTER TABLE [dbo].[ActorSkill] ADD CONSTRAINT [PK_ActorSkill] PRIMARY KEY CLUSTERED  ([ActorIdFk], [SkillIdFk]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[Feat]'
GO
CREATE TABLE [dbo].[Feat]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IsRepeatable] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_Feat] on [dbo].[Feat]'
GO
ALTER TABLE [dbo].[Feat] ADD CONSTRAINT [PK_Feat] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[Race]'
GO
CREATE TABLE [dbo].[Race]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Size] [tinyint] NULL
) ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_Race] on [dbo].[Race]'
GO
ALTER TABLE [dbo].[Race] ADD CONSTRAINT [PK_Race] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[CharacterClass]'
GO
CREATE TABLE [dbo].[CharacterClass]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_CharacterClass] on [dbo].[CharacterClass]'
GO
ALTER TABLE [dbo].[CharacterClass] ADD CONSTRAINT [PK_CharacterClass] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[Power]'
GO
CREATE TABLE [dbo].[Power]
(
[Id] [int] NOT NULL,
[Name] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Level] [int] NULL,
[Type] [tinyint] NULL,
[Action] [tinyint] NULL,
[Keywords] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[FlavorText] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Description] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_Power] on [dbo].[Power]'
GO
ALTER TABLE [dbo].[Power] ADD CONSTRAINT [PK_Power] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[ActorBonus]'
GO
CREATE TABLE [dbo].[ActorBonus]
(
[ActorIdFk] [int] NOT NULL,
[Name] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Type] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Bonus] [int] NULL
) ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_ActorBonus] on [dbo].[ActorBonus]'
GO
ALTER TABLE [dbo].[ActorBonus] ADD CONSTRAINT [PK_ActorBonus] PRIMARY KEY CLUSTERED  ([ActorIdFk], [Name]) ON [PRIMARY]
GO
PRINT N'Adding foreign keys to [dbo].[ActorBonus]'
GO
ALTER TABLE [dbo].[ActorBonus] ADD
CONSTRAINT [FK_ActorBonus_Actor] FOREIGN KEY ([ActorIdFk]) REFERENCES [dbo].[Actor] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
GO
PRINT N'Adding foreign keys to [dbo].[ActorFeat]'
GO
ALTER TABLE [dbo].[ActorFeat] ADD
CONSTRAINT [FK_ActorFeat_Actor] FOREIGN KEY ([ActorIdFk]) REFERENCES [dbo].[Actor] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT [FK_ActorFeat_Feat] FOREIGN KEY ([FeatIdFk]) REFERENCES [dbo].[Feat] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
GO
PRINT N'Adding foreign keys to [dbo].[ActorPower]'
GO
ALTER TABLE [dbo].[ActorPower] ADD
CONSTRAINT [FK_ActorPower_Actor] FOREIGN KEY ([ActorIdFk]) REFERENCES [dbo].[Actor] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT [FK_ActorPower_Power] FOREIGN KEY ([PowerIdFk]) REFERENCES [dbo].[Power] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
GO
PRINT N'Adding foreign keys to [dbo].[ActorSkill]'
GO
ALTER TABLE [dbo].[ActorSkill] ADD
CONSTRAINT [FK_ActorSkill_Actor] FOREIGN KEY ([ActorIdFk]) REFERENCES [dbo].[Actor] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
GO
PRINT N'Adding foreign keys to [dbo].[Actor]'
GO
ALTER TABLE [dbo].[Actor] ADD
CONSTRAINT [FK_Actor_Player] FOREIGN KEY ([PlayerFK]) REFERENCES [dbo].[Player] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT [FK_Actor_CharacterClass] FOREIGN KEY ([CharacterClassFK]) REFERENCES [dbo].[CharacterClass] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT [FK_Actor_Race] FOREIGN KEY ([RaceFK]) REFERENCES [dbo].[Race] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE,
CONSTRAINT [FK_Actor_Deity] FOREIGN KEY ([DeityFK]) REFERENCES [dbo].[Deity] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
GO

GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script		
 Use SQLCMD syntax to include a file into the post-deployment script			
 Example:      :r .\filename.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/










USE [$(DatabaseName)]
IF ((SELECT COUNT(*) 
	FROM 
		::fn_listextendedproperty( 'microsoft_database_tools_deploystamp', null, null, null, null, null, null )) 
	> 0)
BEGIN
	EXEC [dbo].sp_dropextendedproperty 'microsoft_database_tools_deploystamp'
END
EXEC [dbo].sp_addextendedproperty 'microsoft_database_tools_deploystamp', N'f965f691-14fd-41c2-b024-e099e0a06e76'
GO

