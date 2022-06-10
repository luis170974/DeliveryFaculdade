CREATE TABLE [dbo].[TBLOGIN] (
    [numero]      INT          IDENTITY (1, 1) NOT NULL,
    [login]       VARCHAR (50) NOT NULL,
    [senha]       VARCHAR (50) NOT NULL,
    [tipo_acesso] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK__TBLOGIN__7500EDCAF8A09EF2] PRIMARY KEY CLUSTERED ([numero] ASC)
);

