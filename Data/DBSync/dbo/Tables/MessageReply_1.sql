CREATE TABLE [dbo].[MessageReply] (
    [MessageReplyId] INT            IDENTITY (1, 1) NOT NULL,
    [Body]           NVARCHAR (MAX) NULL,
    [MessageId]      INT            NOT NULL,
    [ActiveStatusId] INT            NOT NULL,
    [CreatedDate]    NVARCHAR (MAX) NULL,
    [UpdatedDate]    NVARCHAR (MAX) NULL,
    [UserId]         INT            NOT NULL,
    CONSTRAINT [PK_MessageReply] PRIMARY KEY CLUSTERED ([MessageReplyId] ASC),
    FOREIGN KEY ([MessageId]) REFERENCES [dbo].[Message] ([MessageId]),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]),
    CONSTRAINT [FK_MessageReply_Message_MessageId] FOREIGN KEY ([MessageId]) REFERENCES [dbo].[Message] ([MessageId]) ON DELETE CASCADE
);

