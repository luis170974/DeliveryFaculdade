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
    public class RepositorioProdutoEmBancoDados : RepositorioBase<Produto, MapeadorProduto, ValidadorProduto>
    {



        protected override string Sql_insercao => @"INSERT INTO [TBPRODUTO]
                (
                    NOME,
                    PRECO,
                    QUANTIDADE
                )
            VALUES
                (
                    @NOME
                    @PRECO
                    @QUANTIDADE

                ); 
                SELECT SCOPE_IDENTITY();";

        protected override string Sql_edicao => @"UPDATE[TBPRODUTO] SET

                    NOME = @NOME,
                    PRECO = @PRECO,
                    QUANTIDADE = @QUANTIDADE

                   WHERE
                         ID = @ID";

        protected override string Sql_exclusao => @"DELETE FROM TBPRODUTO WHERE ID = @ID";

        protected override string Sql_selecao_por_id => @"SELECT * FROM TBPRODUTO WHERE ID = @ID";

        protected override string Sql_selecao_todos => @"SELECT * FROM TBPRODUTO";

        public ValidationResult Inserir(Produto novoRegistro)
        {
            ValidationResult resultado = Validar(novoRegistro)
        }
        public ValidationResult Editar(Produto registro)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Excluir(Produto registro)
        {
            throw new NotImplementedException();
        }

        public Produto SelecionarPorId(int numero)
        {
            throw new NotImplementedException();
        }

        public List<Produto> SelecionarTodos()
        {
            ConectarBancoDados();

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos);


            SqlDataReader leitorPedido = comandoSelecao.ExecuteReader();

            List<Produto> produtos = new List<Produto>();

            while (leitorPedido.Read())
            {
                Produto produto = ConverterParaProduto(leitorPedido);

                produtos.Add(produto);
            }

            DesconectarBancoDados();

            return produtos;
        }

        protected override ValidationResult Validar(Produto entidade)
        {
            return new ValidadorFornecedor().Validate(entidade);
        }



    }
}
