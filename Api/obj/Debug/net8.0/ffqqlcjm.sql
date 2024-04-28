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

CREATE TABLE [Estado] (
    [Id] int NOT NULL IDENTITY,
    [Descricao] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Estado] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Anime] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Autor] nvarchar(max) NOT NULL,
    [ImgUrl] nvarchar(max) NULL,
    [EstadoId] int NOT NULL,
    CONSTRAINT [PK_Anime] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Anime_Estado_EstadoId] FOREIGN KEY ([EstadoId]) REFERENCES [Estado] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Comentario] (
    [Id] nvarchar(450) NOT NULL,
    [Descricao] nvarchar(max) NOT NULL,
    [Estrelas] int NOT NULL,
    [PersonagemID] int NOT NULL,
    [PostID] int NOT NULL,
    [EstadoId] int NOT NULL,
    CONSTRAINT [PK_Comentario] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Comentario_Estado_EstadoId] FOREIGN KEY ([EstadoId]) REFERENCES [Estado] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Personagem] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Usuario] nvarchar(max) NOT NULL,
    [Senha] nvarchar(max) NOT NULL,
    [Token] nvarchar(max) NOT NULL,
    [ImgUrl] nvarchar(max) NULL,
    [AnimeId] int NOT NULL,
    [EstadoId] int NOT NULL,
    [PostId] int NULL,
    CONSTRAINT [PK_Personagem] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Personagem_Anime_AnimeId] FOREIGN KEY ([AnimeId]) REFERENCES [Anime] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Personagem_Estado_EstadoId] FOREIGN KEY ([EstadoId]) REFERENCES [Estado] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [PersonagemPersonagem] (
    [ASeguirId] int NOT NULL,
    [SeguidoresId] int NOT NULL,
    CONSTRAINT [PK_PersonagemPersonagem] PRIMARY KEY ([ASeguirId], [SeguidoresId]),
    CONSTRAINT [FK_PersonagemPersonagem_Personagem_ASeguirId] FOREIGN KEY ([ASeguirId]) REFERENCES [Personagem] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PersonagemPersonagem_Personagem_SeguidoresId] FOREIGN KEY ([SeguidoresId]) REFERENCES [Personagem] ([Id])
);
GO

CREATE TABLE [Post] (
    [Id] int NOT NULL IDENTITY,
    [Descricao] nvarchar(max) NOT NULL,
    [ImgUrl] nvarchar(max) NULL,
    [PersonagemID] int NOT NULL,
    [EstadoId] int NOT NULL,
    CONSTRAINT [PK_Post] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Post_Estado_EstadoId] FOREIGN KEY ([EstadoId]) REFERENCES [Estado] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Post_Personagem_PersonagemID] FOREIGN KEY ([PersonagemID]) REFERENCES [Personagem] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Anime_EstadoId] ON [Anime] ([EstadoId]);
GO

CREATE INDEX [IX_Comentario_EstadoId] ON [Comentario] ([EstadoId]);
GO

CREATE INDEX [IX_Comentario_PersonagemID] ON [Comentario] ([PersonagemID]);
GO

CREATE INDEX [IX_Comentario_PostID] ON [Comentario] ([PostID]);
GO

CREATE INDEX [IX_Personagem_AnimeId] ON [Personagem] ([AnimeId]);
GO

CREATE INDEX [IX_Personagem_EstadoId] ON [Personagem] ([EstadoId]);
GO

CREATE INDEX [IX_Personagem_PostId] ON [Personagem] ([PostId]);
GO

CREATE INDEX [IX_PersonagemPersonagem_SeguidoresId] ON [PersonagemPersonagem] ([SeguidoresId]);
GO

CREATE INDEX [IX_Post_EstadoId] ON [Post] ([EstadoId]);
GO

CREATE INDEX [IX_Post_PersonagemID] ON [Post] ([PersonagemID]);
GO

ALTER TABLE [Comentario] ADD CONSTRAINT [FK_Comentario_Personagem_PersonagemID] FOREIGN KEY ([PersonagemID]) REFERENCES [Personagem] ([Id]) ON DELETE NO ACTION;
GO

ALTER TABLE [Comentario] ADD CONSTRAINT [FK_Comentario_Post_PostID] FOREIGN KEY ([PostID]) REFERENCES [Post] ([Id]) ON DELETE NO ACTION;
GO

ALTER TABLE [Personagem] ADD CONSTRAINT [FK_Personagem_Post_PostId] FOREIGN KEY ([PostId]) REFERENCES [Post] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240405154325_otakumeet', N'8.0.3');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Personagem]') AND [c].[name] = N'Usuario');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Personagem] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Personagem] DROP COLUMN [Usuario];
GO

CREATE TABLE [Usuario] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Senha] nvarchar(max) NOT NULL,
    [PersonagemId] int NOT NULL,
    [EstadoId] int NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Usuario_Estado_EstadoId] FOREIGN KEY ([EstadoId]) REFERENCES [Estado] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Usuario_Personagem_PersonagemId] FOREIGN KEY ([PersonagemId]) REFERENCES [Personagem] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Usuario_EstadoId] ON [Usuario] ([EstadoId]);
GO

CREATE UNIQUE INDEX [IX_Usuario_PersonagemId] ON [Usuario] ([PersonagemId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240407135427_usuario', N'8.0.3');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Personagem]') AND [c].[name] = N'Senha');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Personagem] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Personagem] DROP COLUMN [Senha];
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Personagem]') AND [c].[name] = N'Token');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Personagem] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Personagem] DROP COLUMN [Token];
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240407143409_senha', N'8.0.3');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Chat] (
    [Id] int NOT NULL IDENTITY,
    [PrimeiraPersonagemId] int NOT NULL,
    [SegundaPersonagemId] int NOT NULL,
    [EstadoId] int NOT NULL,
    CONSTRAINT [PK_Chat] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Chat_Estado_EstadoId] FOREIGN KEY ([EstadoId]) REFERENCES [Estado] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Chat_Personagem_PrimeiraPersonagemId] FOREIGN KEY ([PrimeiraPersonagemId]) REFERENCES [Personagem] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Chat_Personagem_SegundaPersonagemId] FOREIGN KEY ([SegundaPersonagemId]) REFERENCES [Personagem] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Mensagem] (
    [Id] int NOT NULL IDENTITY,
    [Descricao] nvarchar(max) NOT NULL,
    [PersonagemId] int NOT NULL,
    [ToPersonagemId] int NOT NULL,
    [ChatId] int NOT NULL,
    [EstadoId] int NOT NULL,
    [Data] datetime2 NOT NULL,
    CONSTRAINT [PK_Mensagem] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Mensagem_Chat_ChatId] FOREIGN KEY ([ChatId]) REFERENCES [Chat] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Mensagem_Estado_EstadoId] FOREIGN KEY ([EstadoId]) REFERENCES [Estado] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Mensagem_Personagem_PersonagemId] FOREIGN KEY ([PersonagemId]) REFERENCES [Personagem] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Mensagem_Personagem_ToPersonagemId] FOREIGN KEY ([ToPersonagemId]) REFERENCES [Personagem] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Chat_EstadoId] ON [Chat] ([EstadoId]);
GO

CREATE INDEX [IX_Chat_PrimeiraPersonagemId] ON [Chat] ([PrimeiraPersonagemId]);
GO

CREATE INDEX [IX_Chat_SegundaPersonagemId] ON [Chat] ([SegundaPersonagemId]);
GO

CREATE INDEX [IX_Mensagem_ChatId] ON [Mensagem] ([ChatId]);
GO

CREATE INDEX [IX_Mensagem_EstadoId] ON [Mensagem] ([EstadoId]);
GO

CREATE INDEX [IX_Mensagem_PersonagemId] ON [Mensagem] ([PersonagemId]);
GO

CREATE INDEX [IX_Mensagem_ToPersonagemId] ON [Mensagem] ([ToPersonagemId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240409140120_hub', N'8.0.3');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Mensagem] DROP CONSTRAINT [FK_Mensagem_Chat_ChatId];
GO

ALTER TABLE [Mensagem] DROP CONSTRAINT [FK_Mensagem_Personagem_ToPersonagemId];
GO

DROP TABLE [Chat];
GO

DROP INDEX [IX_Mensagem_ChatId] ON [Mensagem];
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Mensagem]') AND [c].[name] = N'ChatId');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Mensagem] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Mensagem] DROP COLUMN [ChatId];
GO

EXEC sp_rename N'[Mensagem].[ToPersonagemId]', N'ToGrupoId', N'COLUMN';
GO

EXEC sp_rename N'[Mensagem].[IX_Mensagem_ToPersonagemId]', N'IX_Mensagem_ToGrupoId', N'INDEX';
GO

CREATE TABLE [ConexaoPersonagem] (
    [Id] int NOT NULL IDENTITY,
    [PersonagemId] int NOT NULL,
    [Conexao] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_ConexaoPersonagem] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ConexaoPersonagem_Personagem_PersonagemId] FOREIGN KEY ([PersonagemId]) REFERENCES [Personagem] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Grupo] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [PrimeiraPersonagemId] int NOT NULL,
    [SegundaPersonagemId] int NOT NULL,
    [EstadoId] int NOT NULL,
    CONSTRAINT [PK_Grupo] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Grupo_Estado_EstadoId] FOREIGN KEY ([EstadoId]) REFERENCES [Estado] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Grupo_Personagem_PrimeiraPersonagemId] FOREIGN KEY ([PrimeiraPersonagemId]) REFERENCES [Personagem] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Grupo_Personagem_SegundaPersonagemId] FOREIGN KEY ([SegundaPersonagemId]) REFERENCES [Personagem] ([Id]) ON DELETE NO ACTION
);
GO

CREATE UNIQUE INDEX [IX_ConexaoPersonagem_PersonagemId] ON [ConexaoPersonagem] ([PersonagemId]);
GO

CREATE INDEX [IX_Grupo_EstadoId] ON [Grupo] ([EstadoId]);
GO

CREATE INDEX [IX_Grupo_PrimeiraPersonagemId] ON [Grupo] ([PrimeiraPersonagemId]);
GO

CREATE INDEX [IX_Grupo_SegundaPersonagemId] ON [Grupo] ([SegundaPersonagemId]);
GO

ALTER TABLE [Mensagem] ADD CONSTRAINT [FK_Mensagem_Grupo_ToGrupoId] FOREIGN KEY ([ToGrupoId]) REFERENCES [Grupo] ([Id]) ON DELETE CASCADE;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240411090402_conexao', N'8.0.3');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Comentario] DROP CONSTRAINT [PK_Comentario];
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Comentario]') AND [c].[name] = N'Id');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Comentario] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Comentario] DROP COLUMN [Id];
GO

ALTER TABLE [Comentario] ADD [ComentarioId] int NOT NULL IDENTITY;
GO

ALTER TABLE [Comentario] ADD CONSTRAINT [PK_Comentario] PRIMARY KEY ([ComentarioId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240414085604_comentario', N'8.0.3');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[Comentario].[ComentarioId]', N'Id', N'COLUMN';
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240414085842_comentarioUp', N'8.0.3');
GO

COMMIT;
GO

