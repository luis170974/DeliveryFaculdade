CREATE TABLE [dbo].[TBPRODUTO] (
    [id]         INT          IDENTITY (1, 1) NOT NULL,
    [nome]       VARCHAR (50) NOT NULL,
    [preco]      MONEY        NOT NULL,
    [quantidade] INT          NOT NULL,
    CONSTRAINT [PK_TBPRODUTO] PRIMARY KEY CLUSTERED ([id] ASC)
);

