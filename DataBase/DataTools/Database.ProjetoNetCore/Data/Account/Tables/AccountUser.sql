CREATE TABLE [Account].[User]
(
	[Id]                   UNIQUEIDENTIFIER   NOT NULL DEFAULT (newid()),
    [Name]                 NVARCHAR (500)     NOT NULL,
    [Email]                NVARCHAR (500)     NOT NULL,
    [EmailConfirmed]       BIT                NOT NULL,
    [Password]             NVARCHAR (MAX)     NOT NULL,
    [AccessFailedCount]    INT                NOT NULL,
    [Lockout]              BIT                NOT NULL,
    [LockoutEnd]           DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_AccountUser] PRIMARY KEY CLUSTERED ([Id] ASC)
)
