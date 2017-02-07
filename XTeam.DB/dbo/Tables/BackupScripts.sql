﻿CREATE TABLE [dbo].[Scripts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	Name NVARCHAR(100),
	SqlCommand NVARCHAR(MAX),
	CreatedBy NVARCHAR(50),
	CreatedOn DATETIME2,
	ModifiedBy NVARCHAR(50),
	ModifiedOn DATETIME2
)
