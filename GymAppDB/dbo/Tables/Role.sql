﻿CREATE TABLE [dbo].[Role] (
    [RoleID] INT           IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([RoleID] ASC)
);

