CREATE TABLE [dbo].[User] (
    [UserID]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50)  NOT NULL,
    [LastName]     NVARCHAR (100) NOT NULL,
    [Password]     NVARCHAR (MAX) NOT NULL,
    [Nickname]     NVARCHAR (50)  NOT NULL,
    [Age]          INT            NOT NULL,
    [CreatedDate]  DATETIME       NULL,
    [ModifiedDate] DATETIME       NULL,
    [CreatedBy]    DATETIME       NULL,
    [ModifiedBy]   DATETIME       NULL,
    [RoleID]       INT            NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [FK_User_Role] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Role] ([RoleID])
);





