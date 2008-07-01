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


