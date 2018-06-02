CREATE TABLE [dbo].[User] (
    [UserID]   INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (50)  NOT NULL,
    [LastName] NVARCHAR (100) NOT NULL,
    [Age]      INT            NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserID] ASC)
);



