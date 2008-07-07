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


