using DeliveryFaculdade.Dominio.Compartilhado;
using DeliveryFaculdade.Dominio.ModuloPessoa;
using DeliveryFaculdade.Dominio.ModuloProduto;
using DeliveryFaculdade.Infra.BancoDados.Compartilhado;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryFaculdade.Infra.BancoDados.ModuloPessoa
{
    public class RepositorioPessoaEmBancoDados : RepositorioBase<Pessoa, MapeadorPessoa, ValidadorPessoa>
    {
        ValidadorPessoa validadorPessoa;

        protected override string Sql_insercao => @"INSERT INTO [TBPESSOA]
                (
                    NOME,
                    DATANASCIMENTO,
                    CPF,
                    ESTADOONDEMORA,
                    TELEFONE,
                    USUARIO,
                    SENHA,
                    TIPO_ACESSO,
                    EMAIL,
                    LOGRADOURO
                )
            VALUES
                (
                    @NOME,
                    @DATANASCIMENTO,
                    @CPF,
                    @ESTADOONDEMORA,
                    @TELEFONE,
                    @USUARIO,
                    @SENHA,
                    @TIPO_ACESSO,
                    @EMAIL,
                    @LOGRADOURO

                ); 
                SELECT SCOPE_IDENTITY();";

        protected override string Sql_edicao => @"UPDATE[TBPESSOA] SET

                        NOME = @NOME,
                        DATANASCIMENTO = @DATANASCIMENTO,
                        CPF = @CPF,
                        ESTADOONDEMORA = @ESTADOONDEMORA,
                        TELEFONE = @TELEFONE,
                        USUARIO = @USUARIO,
                        TIPO_ACESSO = @TIPO_ACESSO,
                        EMAIL = @EMAIL,
                        LOGRADOURO = @LOGRADOURO

                   WHERE
                         ID = @ID";

        protected override string Sql_exclusao => @"DELETE FROM TBPESSOA WHERE ID = @ID";

        protected override string Sql_selecao_por_id => @"SELECT * FROM TBPESSOA WHERE ID = @ID";

        protected override string Sql_selecao_todos => @"SELECT * FROM TBPESSOA";

        public ValidationResult Inserir(Pessoa novoRegistro)
        {
            ValidationResult resultado = Validar(novoRegistro);
        }

        public ValidationResult Editar(Pessoa registro)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Excluir(Pessoa registro)
        {
            throw new NotImplementedException();
        }



        public List<Pessoa> SelecionarTodos()
        {
            throw new NotImplementedException();

        }
        public Pessoa SelecionarPorId(int numero)
        {
            throw new NotImplementedException();
        }
    }
}
