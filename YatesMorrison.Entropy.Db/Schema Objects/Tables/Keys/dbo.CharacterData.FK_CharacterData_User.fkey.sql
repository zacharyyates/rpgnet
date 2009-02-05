ALTER TABLE [dbo].[CharacterData] ADD
CONSTRAINT [FK_CharacterData_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id])


