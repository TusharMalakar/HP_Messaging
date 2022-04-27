CREATE TABLE [dbo].[Message] (
    [MessageId]      INT            IDENTITY (1, 1) NOT NULL,
    [Body]           NVARCHAR (MAX) NULL,
    [ActiveStatusId] INT            NOT NULL,
    [CreatedDate]    NVARCHAR (MAX) NULL,
    [UpdatedDate]    NVARCHAR (MAX) NULL,
    [UserId]         INT            NOT NULL,
    CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED ([MessageId] ASC),
    CONSTRAINT [FK_Message_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]) ON DELETE CASCADE
);

