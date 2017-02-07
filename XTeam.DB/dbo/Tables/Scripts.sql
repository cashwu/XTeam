CREATE TABLE [dbo].[BackupScripts]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	ScriptId INT,
	Name NVARCHAR(100),
	SqlCommand NVARCHAR(MAX),
	CreatedBy NVARCHAR(50),
	CreatedOn DATETIME2,
	ModifiedBy NVARCHAR(50),
	ModifiedOn DATETIME2
)
