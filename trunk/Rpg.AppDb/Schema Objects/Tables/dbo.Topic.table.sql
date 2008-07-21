CREATE TABLE [dbo].[Topic]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Name] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Content] [nvarchar] (max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Version] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


