IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [TB_TAREFAS] (
    [Id] int NOT NULL IDENTITY,
    [Nome] varchar(500) NOT NULL,
    [Descrição] varchar(500) NOT NULL,
    [Prioridade] int NOT NULL,
    [Status] int NOT NULL,
    [DataCriacao] datetime2 NULL,
    CONSTRAINT [PK_TB_TAREFAS] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataCriacao', N'Descrição', N'Nome', N'Prioridade', N'Status') AND [object_id] = OBJECT_ID(N'[TB_TAREFAS]'))
    SET IDENTITY_INSERT [TB_TAREFAS] ON;
INSERT INTO [TB_TAREFAS] ([Id], [DataCriacao], [Descrição], [Nome], [Prioridade], [Status])
VALUES (1, NULL, 'Lavar a louça antes da mãe chegar', 'Lavar a Louça', 3, 1),
(2, NULL, 'Estudar c# para proxima prova', 'Estudar para prova', 1, 2),
(3, NULL, 'Fazer o trabalho de fisica', 'Fazer trabalho escolar', 3, 2),
(4, NULL, 'Ir a academia', 'Academia', 2, 1),
(5, NULL, 'Revisar conteudo passado na aula de DS', 'Revisar conteudo passado aula', 3, 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'DataCriacao', N'Descrição', N'Nome', N'Prioridade', N'Status') AND [object_id] = OBJECT_ID(N'[TB_TAREFAS]'))
    SET IDENTITY_INSERT [TB_TAREFAS] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240429132756_InitialCreate', N'8.0.4');
GO

COMMIT;
GO

