CREATE TABLE [dbo].[TBPEDIDO] (
    [id]          INT          NOT NULL,
    [tipo_pedido] VARCHAR (50) NOT NULL,
    [pessoa_id]   INT          NOT NULL,
    [valorPedido] MONEY        NOT NULL,
    [dataPedido]  DATE         NOT NULL,
    CONSTRAINT [PK_TBPEDIDO] PRIMARY KEY CLUSTERED ([id] ASC)
);

