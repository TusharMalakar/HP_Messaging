CREATE TABLE [dbo].[User] (
    [UserId]      INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (MAX) NULL,
    [LastName]    NVARCHAR (MAX) NULL,
    [Email]       NVARCHAR (MAX) NULL,
    [Password]    NVARCHAR (MAX) NULL,
    [CreatedDate] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

