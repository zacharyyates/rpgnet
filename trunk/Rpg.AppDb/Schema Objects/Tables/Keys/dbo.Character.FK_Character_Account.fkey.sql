ALTER TABLE [dbo].[Character] ADD
CONSTRAINT [FK_Character_Account] FOREIGN KEY ([AccountIdFk]) REFERENCES [dbo].[Account] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE


