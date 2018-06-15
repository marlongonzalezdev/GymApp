CREATE TABLE [dbo].[User] (
    [UserID]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50)  NOT NULL,
    [LastName]     NVARCHAR (100) NOT NULL,
    [Password]     NVARCHAR (MAX) NOT NULL,
    [Nickname]     NVARCHAR (50)  NOT NULL,
    [Birthday]     DATE           NOT NULL,
    [CreatedDate]  DATETIME       NOT NULL,
    [ModifiedDate] DATETIME       NOT NULL,
    [CreatedBy]    NVARCHAR (50)  NOT NULL,
    [ModifiedBy]   NVARCHAR (50)  NOT NULL,
    [RoleID]       INT            NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [FK_User_Role] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Role] ([RoleID])
);







