ALTER TABLE [dbo].[ObjectTemplate] ADD
CONSTRAINT [FK_ObjectTemplate_User] FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[User] ([Id])


