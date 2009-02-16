CREATE TABLE [dbo].[CharacterInstance]
(
[Id] [uniqueidentifier] NOT NULL,
[GameId] [uniqueidentifier] NULL,
[UserId] [uniqueidentifier] NULL,
[Name] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Data] [varbinary] (max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


