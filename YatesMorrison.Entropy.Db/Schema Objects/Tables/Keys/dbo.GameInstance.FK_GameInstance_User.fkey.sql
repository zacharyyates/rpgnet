ALTER TABLE [dbo].[GameInstance] ADD
CONSTRAINT [FK_GameInstance_User] FOREIGN KEY ([MasterId]) REFERENCES [dbo].[User] ([Id])


