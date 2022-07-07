using DeliveryFaculdade.Dominio.Compartilhado;
using DeliveryFaculdade.Dominio.ModuloProduto;
using DeliveryFaculdade.Infra.BancoDados.Compartilhado;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryFaculdade.Infra.BancoDados.ModuloProduto
{
    public class RepositorioProdutoEmBancoDados : ConexaoBancoDados<Produto>, IRepositorio<Produto>
    {

        public ValidationResult Inserir(Produto entidade)
        {
            ValidationResult resultado = Validar(entidade);

            if (resultado.IsValid)
                InserirRegistroBancoDados(entidade);

            return resultado;
        }

        public ValidationResult Editar(Produto entidade)
        {
            ValidationResult resultado = Validar(entidade);

            if (resultado.IsValid)
                EditarRegistroBancoDados(entidade);

            return resultado;
        }

        public ValidationResult Excluir(Produto entidade)
        {
            ValidationResult resultado = Validar(entidade);

            if (resultado.IsValid)
                ExcluirRegistroBancoDados(entidade);

            return resultado;
        }



        public List<Produto> SelecionarTodos()
        {
            ConectarBancoDados();

            sql = @"SELECT * FROM TBPRODUTO";

            SqlCommand cmd_Selecao = new(sql, conexao);

            SqlDataReader leitor = cmd_Selecao.ExecuteReader();

            List<Produto> produtos = LerTodos(leitor);

            DesconectarBancoDados();

            return produtos;
        }

        public Produto SelecionarUnico(int numero)
        {
            ConectarBancoDados();

            sql = @"SELECT * FROM TBPRODUTO WHERE ID = @ID";

            SqlCommand cmdSelecao = new(sql, conexao);

            cmdSelecao.Parameters.AddWithValue("ID", numero);

            SqlDataReader leitor = cmdSelecao.ExecuteReader();

            Produto selecionado = LerUnico(leitor);

            DesconectarBancoDados();

            return selecionado;
        }

        #region metodos protected
        protected override void DefinirParametros(Produto entidade, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("NOME", entidade.Nome);
            cmd.Parameters.AddWithValue("PRECO", entidade.Preco);
            cmd.Parameters.AddWithValue("QUANTIDADE", entidade.Quantidade);

        }

        protected override void EditarRegistroBancoDados(Produto entidade)
        {
            ConectarBancoDados();

            sql = @"UPDATE[TBPRODUTO] SET

                    NOME = @NOME,
                    PRECO = @PRECO,
                    QUANTIDADE = @QUANTIDADE

                   WHERE
                         ID = @ID";

            SqlCommand cmd_Edicao = new(sql, conexao);

            DefinirParametros(entidade, cmd_Edicao);

            cmd_Edicao.ExecuteNonQuery();

            DesconectarBancoDados();
        }

        protected override void ExcluirRegistroBancoDados(Produto entidade)
        {
            ConectarBancoDados();

            sql = @"DELETE FROM TBPRODUTO WHERE ID = @ID";

            SqlCommand cmd_Exclusao = new(sql, conexao);

            cmd_Exclusao.Parameters.AddWithValue("ID", entidade.Id);

            cmd_Exclusao.ExecuteNonQuery();

            DesconectarBancoDados();
        }

        protected override void InserirRegistroBancoDados(Produto entidade)
        {
            ConectarBancoDados();

            sql = @"INSERT INTO [TBPRODUTO]
                (
                    NOME,
                    PRECO,
                    QUANTIDADE
                )
            VALUES
                (
                    @NOME,
                    @PRECO,
                    @QUANTIDADE

                ); 
                SELECT SCOPE_IDENTITY();";

            SqlCommand cmd_Insercao = new(sql, conexao);

            DefinirParametros(entidade, cmd_Insercao);

            entidade.Id = Convert.ToInt32(cmd_Insercao.ExecuteScalar());

            DesconectarBancoDados();
        }

        protected override List<Produto> LerTodos(SqlDataReader leitor)
        {
            List<Produto> produtos = new();

            while (leitor.Read())
            {
                int id = Convert.ToInt32(leitor["ID"]);
                string nome = leitor["NOME"].ToString();
                string preco = leitor["PRECO"].ToString();
                string quantidade = leitor["QUANTIDADE"].ToString();


                Produto produto = new Produto(nome, preco, quantidade )
                {
                    Id = id
                };

                produtos.Add(produto);
            }

            return produtos;
        }

        protected override Produto LerUnico(SqlDataReader leitor)
        {
            Produto produto = null;

            if (leitor.Read())
            {
                int id = Convert.ToInt32(leitor["ID"]);
                string nome = leitor["NOME"].ToString();
                string preco = leitor["PRECO"].ToString();
                string quantidade = leitor["QUANTIDADE"].ToString();

                produto = new Produto(nome, preco, quantidade)
                {
                    Id = id
                };
            }

            return produto;
        }

        protected override ValidationResult Validar(Produto entidade)
        {
            return new ValidadorProduto().Validate(entidade);
        }

        #endregion
    }
}
