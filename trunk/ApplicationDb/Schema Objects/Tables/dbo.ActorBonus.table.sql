CREATE TABLE [dbo].[ActorBonus]
(
[ActorIdFk] [int] NOT NULL,
[Name] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
[Type] [nvarchar] (50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
[Bonus] [int] NULL
) ON [PRIMARY]


