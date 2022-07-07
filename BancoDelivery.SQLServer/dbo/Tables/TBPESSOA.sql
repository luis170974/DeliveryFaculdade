CREATE TABLE [dbo].[TBPESSOA] (
    [id]             INT           IDENTITY (1, 1) NOT NULL,
    [nome]           VARCHAR (100) NOT NULL,
    [dataNascimento] DATE          NOT NULL,
    [cpf]            VARCHAR (50)  NOT NULL,
    [estadoOndeMora] VARCHAR (50)  NOT NULL,
    [telefone]       VARCHAR (50)  NOT NULL,
    [usuario]        VARCHAR (50)  NOT NULL,
    [senha]          VARCHAR (50)  NOT NULL,
    [tipo_acesso]    VARCHAR (50)  NOT NULL,
    [email]          VARCHAR (50)  NOT NULL,
    [logradouro]     VARCHAR (50)  NULL,
    [numeroCasa]     VARCHAR (50)  NULL,
    CONSTRAINT [PK_TBPESSOA] PRIMARY KEY CLUSTERED ([id] ASC)
);

