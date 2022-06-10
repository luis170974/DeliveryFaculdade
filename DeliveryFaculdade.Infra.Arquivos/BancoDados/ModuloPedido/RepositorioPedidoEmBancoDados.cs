using DeliveryFaculdade.Dominio.ModuloPedido;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DeliveryFaculdade.Infra.Arquivos.ModuloPedido
{
    public class RepositorioPedidoEmBancoDados : IRepositorioPedido
    {
        private const string enderecoBanco =
       @"Data Source=(LocalDB)\MSSqlLocalDB;
       Initial Catalog=deliveryFaculdadeDb;
       Integrated Security=True;
       Pooling=False";

        private const string sqlInserir =
        @"INSERT INTO [TBDISCIPLINA]
                (
                    TIPO_PEDIDO                 
                )
            VALUES
                (
                    @TIPOPEDIDO

                ); 
                SELECT SCOPE_IDENTITY();";

        private const string sqlSelecionarTodos =
          @"SELECT                 
                PD.NUMERO,       
                PD.TIPO_PEDIDO,
                PD.NUMERO_PESSOA,
                PD.VALORPEDIDO,
                PD.DATAPEDIDO,
                PA.NUMERO,
                PA.NOME,
                PA.TIPO_PESSOA,
                PA.CPF

            FROM
                TBPEDIDO PD INNER JOIN TBPESSOA PA
            ON
                
                PA.NUMERO = PD.NUMERO_PESSOA";

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


        public Pedido SelecionarPorNumero(int numero)
        {
            throw new System.NotImplementedException();
        }

        public List<Pedido> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);

            conexaoComBanco.Open();
            SqlDataReader leitorPedido = comandoSelecao.ExecuteReader();

            List<Pedido> pedidos = new List<Pedido>();

            while (leitorPedido.Read())
            {
                Pedido pedido = ConverterParaPedido(leitorPedido);

                pedidos.Add(pedido);
            }

            conexaoComBanco.Close();

            return pedidos;
        }

        private Pedido ConverterParaPedido(SqlDataReader leitorPedido)
        {
            throw new NotImplementedException();
        }
    }
}