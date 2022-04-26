CREATE TABLE [dbo].[MessageReply](
	[MessageReplyId] [int] IDENTITY(1,1) NOT NULL,
	[Body] [nvarchar](max) NULL,
	[MessageId] [int] NOT NULL,
	[ActiveStatusId] [int] NOT NULL,
	[CreatedDate] [nvarchar](max) NULL,
	[UpdatedDate] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_MessageReply] PRIMARY KEY CLUSTERED 
(
	[MessageReplyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[MessageReply]  WITH CHECK ADD FOREIGN KEY([MessageId])
REFERENCES [dbo].[Message] ([MessageId])
GO

ALTER TABLE [dbo].[MessageReply]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO

ALTER TABLE [dbo].[MessageReply]  WITH CHECK ADD  CONSTRAINT [FK_MessageReply_Message_MessageId] FOREIGN KEY([MessageId])
REFERENCES [dbo].[Message] ([MessageId])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[MessageReply] CHECK CONSTRAINT [FK_MessageReply_Message_MessageId]
GO
