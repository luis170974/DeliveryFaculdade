using DeliveryFaculdade.Dominio.Compartilhado;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryFaculdade.Infra.BancoDados.Compartilhado
{
    public class ConexaoBancoDados
        {
            public SqlConnection conexao;
            public string sql;
            


        public void ConectarBancoDados()
        {
            conexao = new();

            EnderecoBancoDados();

            conexao.Open();
        }

        private void EnderecoBancoDados()
        {
            conexao.ConnectionString = @"Data Source=(LocalDB)\MSSqlLocalDB;Initial Catalog=deliveryFaculdadeDb;Integrated Security=True;Pooling=False";
        }

        public void DesconectarBancoDados()
            {
                conexao.Close();
            }


        }
    }
