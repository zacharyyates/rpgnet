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


