﻿ALTER TABLE [dbo].[TopicTag] ADD
CONSTRAINT [FK_WikiTag_Wiki] FOREIGN KEY ([TopicId]) REFERENCES [dbo].[Topic] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE

