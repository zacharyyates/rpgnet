﻿ALTER TABLE [dbo].[Actor] ADD
CONSTRAINT [FK_Actor_Race] FOREIGN KEY ([RaceFK]) REFERENCES [dbo].[Race] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE


