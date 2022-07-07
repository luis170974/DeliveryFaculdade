using DeliveryFaculdade.Dominio.Compartilhado;
using DeliveryFaculdade.Dominio.ModuloPedido;
using DeliveryFaculdade.Infra.BancoDados.Compartilhado;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DeliveryFaculdade.Infra.Arquivos.ModuloPedido
{
    public class RepositorioPedidoEmBancoDados : ConexaoBancoDados<Pedido>, IRepositorio<Pedido>
    {


        private const string sqlInserir =
        @"INSERT INTO [TBPEDIDO]
                (
                    TIPO_PEDIDO,
                    PESSOA_ID,
                    VALORPEDIDO,
                    DATAPEDIDO
                )
            VALUES
                (
                    @TIPO_PEDIDO,
                    @PESSOA_ID,
                    @VALORPEDIDO,
                    @DATAPEDIDO

                ); 
                SELECT SCOPE_IDENTITY();";

        private const string sqlEditar = @"UPDATE[TBPEDIDO] SET

                    TIPO_PEDIDO = @TIPO_PEDIDO,
                    PESSOA_ID   = @PESSOA_ID,
                    VALORPEDIDO = @VALORPEDIDO,
                    DATAPEDIDO  = @DATAPEDIDO

                   WHERE
                         ID = @ID";

        private const string sqlExcluir = @"DELETE FROM TBPEDIDO WHERE ID = @ID";

        private const string sqlSelecionarPorId = @"SELECT * FROM TBPEDIDO WHERE ID = @ID";

        private const string sqlSelecionarTodos = @"SELECT * FROM TBPEDIDO";

        public ValidationResult Inserir(Pedido entidade)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Editar(Pedido entidade)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Excluir(Pedido entidade)
        {
            throw new NotImplementedException();
        }



        public List<Pedido> SelecionarTodos()
        {
            throw new NotImplementedException();
        }

        public Pedido SelecionarUnico(int numero)
        {
            throw new NotImplementedException();
        }


        protected override void InserirRegistroBancoDados(Pedido entidade)
        {
            throw new NotImplementedException();
        }

        protected override void EditarRegistroBancoDados(Pedido entidade)
        {
            throw new NotImplementedException();
        }

        protected override void ExcluirRegistroBancoDados(Pedido entidade)
        {
            throw new NotImplementedException();
        }

        protected override void DefinirParametros(Pedido entidade, SqlCommand cmd_Insercao)
        {
            throw new NotImplementedException();
        }


        protected override ValidationResult Validar(Pedido entidade)
        {
            throw new NotImplementedException();
        }

        protected override List<Pedido> LerTodos(SqlDataReader leitor)
        {
            throw new NotImplementedException();
        }

        protected override Pedido LerUnico(SqlDataReader leitor)
        {
            throw new NotImplementedException();
        }
    }
}