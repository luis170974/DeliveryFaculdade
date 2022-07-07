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
    public abstract class ConexaoBancoDados<T> where T : EntidadeBase<T>
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


        #region metodos abstratos

        protected abstract void InserirRegistroBancoDados(T entidade);
        protected abstract void EditarRegistroBancoDados(T entidade);
        protected abstract void ExcluirRegistroBancoDados(T entidade);
        protected abstract void DefinirParametros(T entidade, SqlCommand cmd_Insercao);
        protected abstract ValidationResult Validar(T entidade);
        protected abstract List<T> LerTodos(SqlDataReader leitor);
        protected abstract T LerUnico(SqlDataReader leitor);
        protected abstract bool VerificarDuplicidade(string novoTexto);

        #endregion
    }
}
