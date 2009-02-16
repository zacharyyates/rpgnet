CREATE TABLE [dbo].[ObjectTemplate]
(
[Id] [uniqueidentifier] NOT NULL,
[OwnerId] [uniqueidentifier] NULL,
[Name] [nvarchar] (max) NULL,
[IsVisible] [bit] NULL,
[Type] [nvarchar] (max) NULL,
[Data] [varbinary] (max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]


