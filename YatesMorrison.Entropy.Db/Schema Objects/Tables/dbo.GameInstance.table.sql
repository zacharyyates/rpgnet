CREATE TABLE [dbo].[GameInstance]
(
[Id] [uniqueidentifier] NOT NULL,
[MasterId] [uniqueidentifier] NULL,
[Name] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[IsVisible] [bit] NULL,
[Data] [varbinary] (max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


