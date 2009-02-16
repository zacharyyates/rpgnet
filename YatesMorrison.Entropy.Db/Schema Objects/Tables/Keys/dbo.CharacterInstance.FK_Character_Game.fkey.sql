ALTER TABLE [dbo].[CharacterInstance] ADD
CONSTRAINT [FK_Character_Game] FOREIGN KEY ([GameId]) REFERENCES [dbo].[GameInstance] ([Id])


