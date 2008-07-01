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


