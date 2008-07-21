SET  ARITHABORT, CONCAT_NULL_YIELDS_NULL, ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, QUOTED_IDENTIFIER ON 
SET  NUMERIC_ROUNDABORT OFF
GO
:setvar DatabaseName "Rpg.AppDb"
:setvar PrimaryFilePhysicalName "C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\Rpg.AppDb.mdf"
:setvar PrimaryLogFilePhysicalName "C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\DATA\Rpg.AppDb_log.ldf"

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
	    = CAST(N'13c810b8-1af1-40f3-9fb5-f19ddd9dcc6c' AS nvarchar(128)))
    BEGIN
	    RAISERROR(N'Deployment has been skipped because the script has already been deployed to the target server.', 16 ,100) WITH NOWAIT
	    RETURN
    END
END
GO


:on error resume
     
:on error exit

IF (@@servername != 'SKRATASTIC\SQLEXPRESS')
BEGIN
    RAISERROR(N'The server name in the build script %s does not match the name of the target server %s. Verify whether your database project settings are correct and whether your build script is up to date.', 16, 127,N'SKRATASTIC\SQLEXPRESS',@@servername) WITH NOWAIT
    RETURN
END
GO


DECLARE @sqlver as INT;
SET @sqlver = cast(((@@microsoftversion / 0x1000000) * 10) as int);
IF (@sqlver != 90)
BEGIN
    RAISERROR(N'The version of SQL Server in the build script %i does not match the version on the target server %i. Verify whether your database project settings are correct and whether your build script is up to date.', 16, 127,90,@sqlver) WITH NOWAIT;
    RETURN;
END
GO


IF NOT EXISTS (SELECT 1 FROM [master].[dbo].[sysdatabases] WHERE [name] = N'Rpg.AppDb')
BEGIN
    RAISERROR(N'You cannot deploy this update script to target SKRATASTIC\SQLEXPRESS. The database for which this script was built, Rpg.AppDb, does not exist on this server.', 16, 127) WITH NOWAIT
    RETURN
END
GO


IF (N'$(DatabaseName)' ! = N'Rpg.AppDb')
BEGIN
    RAISERROR(N'The database name in the build script %s does not match the name of the target database %s. Verify whether your database project settings are correct and  whether your build script is up to date.', 16, 127,N'$(DatabaseName)',N'Rpg.AppDb') WITH NOWAIT;
    RETURN
END
GO


DECLARE @dbcompatlvl as int;
SELECT  @dbcompatlvl = cmptlevel
FROM    [master].[dbo].[sysdatabases]
WHERE   [name] = N'$(DatabaseName)';
IF (ISNULL(@dbcompatlvl, 0) != 90)
BEGIN
    RAISERROR(N'The database compatibility level of the build script %i does not match the compatibility level of the target database %i. Verify whether your database project settings are correct and whether your build script is up to date.', 16, 127, 90, @dbcompatlvl) WITH NOWAIT;
    RETURN;
END
GO


IF CAST(DATABASEPROPERTY(N'$(DatabaseName)','IsReadOnly') as bit) = 1
BEGIN
    RAISERROR(N'You cannot deploy this update script because the database for which this script was built, %s , is set to READ_ONLY.', 16, 127, N'$(DatabaseName)') WITH NOWAIT
    RETURN
END
GO

:on error resume
     
ALTER DATABASE [$(DatabaseName)] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
ALTER DATABASE [$(DatabaseName)] COLLATE SQL_Latin1_General_CP1_CS_AS;

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
PRINT N'Creating [dbo].[Account]'
GO
CREATE TABLE [dbo].[Account]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Login] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Password] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[DisplayName] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[FirstName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[LastName] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Birthdate] [datetime] NULL,
[PostalCode] [nvarchar] (10) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Country] [nvarchar] (100) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IsSpammable] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_Account] on [dbo].[Account]'
GO
ALTER TABLE [dbo].[Account] ADD CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
PRINT N'Creating [dbo].[Character]'
GO
CREATE TABLE [dbo].[Character]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[AccountIdFk] [int] NOT NULL,
[Name] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Level] [int] NULL,
[Class] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Race] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Alignment] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Created] [datetime] NULL,
[Modified] [datetime] NULL,
[Deleted] [datetime] NULL,
[CharacterObject] [varbinary] (max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
PRINT N'Creating primary key [PK_Character] on [dbo].[Character]'
GO
ALTER TABLE [dbo].[Character] ADD CONSTRAINT [PK_Character] PRIMARY KEY CLUSTERED  ([Id]) ON [PRIMARY]
GO
PRINT N'Adding foreign keys to [dbo].[Character]'
GO
ALTER TABLE [dbo].[Character] ADD
CONSTRAINT [FK_Character_Account] FOREIGN KEY ([AccountIdFk]) REFERENCES [dbo].[Account] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
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
EXEC [dbo].sp_addextendedproperty 'microsoft_database_tools_deploystamp', N'13c810b8-1af1-40f3-9fb5-f19ddd9dcc6c'
GO

