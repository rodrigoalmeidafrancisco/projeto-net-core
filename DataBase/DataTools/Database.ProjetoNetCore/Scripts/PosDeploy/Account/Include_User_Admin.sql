/*
=================================================================================================================
-- Criação da Tabela temporária e as informações que devem ser inseridas na tabela real
=================================================================================================================
*/

DECLARE @TableAccountUser TABLE
(
	[Id]                   UNIQUEIDENTIFIER,   
    [Name]                 NVARCHAR (500),     
    [Email]                NVARCHAR (500),     
    [EmailConfirmed]       BIT,                
    [Password]             NVARCHAR (MAX),     
    [AccessFailedCount]    INT,                
    [Lockout]              BIT,                
    [LockoutEnd]           DATETIMEOFFSET (7) 
)

INSERT INTO @TableAccountUser ([Id], [Name], [Email], [EmailConfirmed], [Password], [AccessFailedCount], [Lockout], [LockoutEnd])
	 VALUES ('4eab749a-ae5a-4618-80d2-514bbcd78c97', 'Administrador', 'adm@netcore.com', 1, '12345', 0, 0, null)

/*
=================================================================================================================
-- Insere ou Atualiza as informações na tabela real
=================================================================================================================
*/

--SET Identity_Insert [Account].[User] ON

MERGE [Account].[User]

USING @TableAccountUser as tmp

-- Condição
ON tmp.Id = [Account].[User].[Id] 

-- Caso a condição seja verdadeira
WHEN MATCHED THEN UPDATE SET 
	 [Account].[User].[Id] = tmp.[Id],
	 [Account].[User].[Name] = tmp.[Name],
     [Account].[User].[Email] = tmp.[Email],
     [Account].[User].[EmailConfirmed] = tmp.[EmailConfirmed],
     [Account].[User].[Password] = tmp.[Password],
     [Account].[User].[AccessFailedCount] = tmp.[AccessFailedCount],
     [Account].[User].[Lockout] = tmp.[Lockout],
     [Account].[User].[LockoutEnd] = tmp.[LockoutEnd]

-- Quando a condição for false
WHEN NOT MATCHED THEN
	INSERT ([Id], [Name], [Email], [EmailConfirmed], [Password], [AccessFailedCount], [Lockout], [LockoutEnd])
	VALUES (tmp.[Id], tmp.[Name], tmp.[Email], tmp.[EmailConfirmed], tmp.[Password], tmp.[AccessFailedCount], tmp.[Lockout], tmp.[LockoutEnd])

-- Quando Existir registra na tabela Original que não tem na @Table variavel Opcional
WHEN NOT MATCHED BY SOURCE THEN
    DELETE;

--SET Identity_Insert [Account].[User] OFF
