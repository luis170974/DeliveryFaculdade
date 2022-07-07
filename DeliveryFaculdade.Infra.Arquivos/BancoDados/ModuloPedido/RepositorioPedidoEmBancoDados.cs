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


        private const string sqlEditar = 

        private const string sqlExcluir = 

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
            sql = @"INSERT INTO [TBPEDIDO]
                (
                    TIPO_PEDIDO,
                    PESSOA_ID,
                    PRODUTO_ID,
                    VALORPEDIDO,
                    DATAPEDIDO
                )
            VALUES
                (
                    @TIPO_PEDIDO,
                    @PESSOA_ID,
                    @PRODUTO_ID,
                    @VALORPEDIDO,
                    @DATAPEDIDO

                ); 
                SELECT SCOPE_IDENTITY();";

            SqlCommand cmd_Insercao = new(sql, conexao);

            DefinirParametros(entidade, cmd_Insercao);

            entidade.Id = Convert.ToInt32(cmd_Insercao.ExecuteScalar());

            DesconectarBancoDados();
        }

        protected override void EditarRegistroBancoDados(Pedido entidade)
        {
            ConectarBancoDados();

            sql = @"UPDATE[TBPEDIDO] SET

                    TIPO_PEDIDO = @TIPO_PEDIDO,
                    PESSOA_ID   = @PESSOA_ID,
                    PRODUTO_ID   = @PRODUTO_ID,
                    VALORPEDIDO = @VALORPEDIDO,
                    DATAPEDIDO  = @DATAPEDIDO

                   WHERE
                         ID = @ID";

            SqlCommand cmd_Edicao = new(sql, conexao);

            DefinirParametros(entidade, cmd_Edicao);

            cmd_Edicao.ExecuteNonQuery();

            DesconectarBancoDados();
        }

        protected override void ExcluirRegistroBancoDados(Pedido entidade)
        {
            ConectarBancoDados();

            sql = @"DELETE FROM TBPEDIDO WHERE ID = @ID";

            SqlCommand cmd_Exclusao = new(sql, conexao);

            cmd_Exclusao.Parameters.AddWithValue("ID", entidade.Id);

            cmd_Exclusao.ExecuteNonQuery();

            DesconectarBancoDados();
        }

        protected override void DefinirParametros(Pedido entidade, SqlCommand cmd_Insercao)
        {
            throw new NotImplementedException();
        }


        protected override ValidationResult Validar(Pedido entidade)
        {
            return new ValidadorPedido().Validate(entidade);
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