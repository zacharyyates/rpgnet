ALTER TABLE [dbo].[CharacterInstance] ADD
CONSTRAINT [FK_CharacterData_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])


