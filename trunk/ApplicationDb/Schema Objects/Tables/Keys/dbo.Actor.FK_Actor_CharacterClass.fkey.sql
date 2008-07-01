ALTER TABLE [dbo].[Actor] ADD
CONSTRAINT [FK_Actor_CharacterClass] FOREIGN KEY ([CharacterClassFK]) REFERENCES [dbo].[CharacterClass] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE


