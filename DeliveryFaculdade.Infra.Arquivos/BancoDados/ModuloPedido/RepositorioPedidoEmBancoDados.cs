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

        public ValidationResult Inserir(Pedido novoRegistro)
        {
            var validador = new ValidadorPedido();

            var resultadoValidacao = validador.Validate(novoRegistro);

            return resultadoValidacao;
        }

        public ValidationResult Editar(Pedido registro)
        {
            throw new System.NotImplementedException();
        }

        public ValidationResult Excluir(Pedido registro)
        {
            throw new System.NotImplementedException();
        }


        public Pedido SelecionarPorId(int numero)
        {
            throw new System.NotImplementedException();
        }

        public List<Pedido> SelecionarTodos()
        {
            ConectarBancoDados();

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos);

            
            SqlDataReader leitorPedido = comandoSelecao.ExecuteReader();

            List<Pedido> pedidos = new List<Pedido>();

            while (leitorPedido.Read())
            {
                Pedido pedido = ConverterParaPedido(leitorPedido);

                pedidos.Add(pedido);
            }

            DesconectarBancoDados();

            return pedidos;
        }

        private Pedido ConverterParaPedido(SqlDataReader leitorPedido)
        {
            throw new NotImplementedException();
        }


    }
}