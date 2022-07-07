using DeliveryFaculdade.Dominio.Compartilhado;
using DeliveryFaculdade.Dominio.ModuloPessoa;
using DeliveryFaculdade.Infra.BancoDados.Compartilhado;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryFaculdade.Infra.BancoDados.ModuloPessoa
{
    public class RepositorioPessoaEmBancoDados : ConexaoBancoDados<Pessoa>, IRepositorio<Pessoa>
    {
        public ValidationResult Inserir(Pessoa entidade)
        {
            ValidationResult resultado = Validar(entidade);

            if (resultado.IsValid)
                InserirRegistroBancoDados(entidade);

            return resultado;
        }

        public ValidationResult Editar(Pessoa entidade)
        {
            ValidationResult resultado = Validar(entidade);

            if (resultado.IsValid)
                EditarRegistroBancoDados(entidade);

            return resultado;
        }

        public ValidationResult Excluir(Pessoa entidade)
        {
            ValidationResult resultado = Validar(entidade);

            if (resultado.IsValid)
                ExcluirRegistroBancoDados(entidade);

            return resultado;
        }



        public List<Pessoa> SelecionarTodos()
        {
            ConectarBancoDados();

            sql = @"SELECT * FROM TBPESSOA";

            SqlCommand cmd_Selecao = new(sql, conexao);

            SqlDataReader leitor = cmd_Selecao.ExecuteReader();

            List<Pessoa> pessoas = LerTodos(leitor);

            DesconectarBancoDados();

            return pessoas;
        }

        public Pessoa SelecionarUnico(int numero)
        {
            ConectarBancoDados();

            sql = @"SELECT * FROM TBPESSOA WHERE ID = @ID";

            SqlCommand cmdSelecao = new(sql, conexao);

            cmdSelecao.Parameters.AddWithValue("ID", numero);

            SqlDataReader leitor = cmdSelecao.ExecuteReader();

            Pessoa selecionado = LerUnico(leitor);

            DesconectarBancoDados();

            return selecionado;
        }

        #region metodos protected
        protected override void DefinirParametros(Pessoa entidade, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("ID", entidade.Id);
            cmd.Parameters.AddWithValue("NOME", entidade.NomePessoa);
            cmd.Parameters.AddWithValue("DATANASCIMENTO", entidade.DataNascimento);
            cmd.Parameters.AddWithValue("CPF", entidade.Cpf);
            cmd.Parameters.AddWithValue("ESTADOONDEMORA", entidade.Estado);
            cmd.Parameters.AddWithValue("TELEFONE", entidade.Telefone);
            cmd.Parameters.AddWithValue("USUARIO", entidade.Usuario);
            cmd.Parameters.AddWithValue("SENHA", entidade.Senha);
            cmd.Parameters.AddWithValue("TIPO_ACESSO", entidade.TipoDoAcesso);
            cmd.Parameters.AddWithValue("EMAIL", entidade.Email);
            cmd.Parameters.AddWithValue("LOGRADOURO", entidade.Logradouro);
            cmd.Parameters.AddWithValue("NUMEROCASA", entidade.NumeroCasa);
        }

        protected override void EditarRegistroBancoDados(Pessoa entidade)
        {
            ConectarBancoDados();

            sql = @"UPDATE[TBPESSOA] SET

                        NOME = @NOME,
                        DATANASCIMENTO = @DATANASCIMENTO,
                        CPF = @CPF,
                        ESTADOONDEMORA = @ESTADOONDEMORA,
                        TELEFONE = @TELEFONE,
                        USUARIO = @USUARIO,
                        SENHA = @SENHA,
                        TIPO_ACESSO = @TIPO_ACESSO,
                        EMAIL = @EMAIL,
                        LOGRADOURO = @LOGRADOURO,
                        NUMEROCASA = @NUMEROCASA

                   WHERE
                         ID = @ID";

            SqlCommand cmd_Edicao = new(sql, conexao);

            DefinirParametros(entidade, cmd_Edicao);

            cmd_Edicao.ExecuteNonQuery();

            DesconectarBancoDados();
        }

        protected override void ExcluirRegistroBancoDados(Pessoa entidade)
        {
            ConectarBancoDados();

            sql = @"DELETE FROM TBPESSOA WHERE ID = @ID";

            SqlCommand cmd_Exclusao = new(sql, conexao);

            cmd_Exclusao.Parameters.AddWithValue("ID", entidade.Id);

            cmd_Exclusao.ExecuteNonQuery();

            DesconectarBancoDados();
        }

        protected override void InserirRegistroBancoDados(Pessoa entidade)
        {
            ConectarBancoDados();

            sql = @"INSERT INTO [TBPESSOA]
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
                    LOGRADOURO,
                    NUMEROCASA
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
                    @LOGRADOURO,
                    @NUMEROCASA

                ); 
                SELECT SCOPE_IDENTITY();";

            SqlCommand cmd_Insercao = new(sql, conexao);

            DefinirParametros(entidade, cmd_Insercao);

            cmd_Insercao.ExecuteNonQuery();

            entidade.Id = Convert.ToInt32(cmd_Insercao.ExecuteScalar());

            DesconectarBancoDados();
        }

        protected override List<Pessoa> LerTodos(SqlDataReader leitor)
        {
            List<Pessoa> pessoas = new();

            while (leitor.Read())
            {
                int id = Convert.ToInt32(leitor["ID"]);
                string nome = leitor["NOME"].ToString();
                DateTime dataNascimento = Convert.ToDateTime(leitor["DATANASCIMENTO"]);
                string cpf = leitor["CPF"].ToString();
                string estado = leitor["ESTADOONDEMORA"].ToString();
                string telefone = leitor["TELEFONE"].ToString();
                string usuario = leitor["USUARIO"].ToString();
                string senha = leitor["SENHA"].ToString();
                string tipoAcesso = leitor["TIPO_ACESSO"].ToString();
                string email = leitor["EMAIL"].ToString();
                string logradouro = leitor["LOGRADOURO"].ToString();
                string numeroCasa = leitor["NUMEROCASA"].ToString();

                Pessoa pessoa = new Pessoa(nome, dataNascimento,cpf,estado,telefone,usuario, senha, tipoAcesso, email,logradouro, numeroCasa)
                
                {
                    Id = id
                };

                pessoas.Add(pessoa);
            }

            return pessoas;
        }

        protected override Pessoa LerUnico(SqlDataReader leitor)
        {
            Pessoa pessoa = null;

            if(leitor.Read())
            {
                int id = Convert.ToInt32(leitor["ID"]);
                string nome = leitor["NOME"].ToString();
                DateTime dataNascimento = Convert.ToDateTime(leitor["DATANASCIMENTO"]);
                string cpf = leitor["CPF"].ToString();
                string estado = leitor["ESTADOONDEMORA"].ToString();
                string telefone = leitor["TELEFONE"].ToString();
                string usuario = leitor["USUARIO"].ToString();
                string senha = leitor["SENHA"].ToString();
                string tipoAcesso = leitor["TIPO_ACESSO"].ToString();
                string email = leitor["EMAIL"].ToString();
                string logradouro = leitor["LOGRADOURO"].ToString();
                string numeroCasa = leitor["NUMEROCASA"].ToString();

                pessoa = new Pessoa(nome, dataNascimento, cpf, estado, telefone, usuario, senha, tipoAcesso, email, logradouro, numeroCasa)
                {
                    Id = id
                };
            }

            return pessoa;
        }

        protected override ValidationResult Validar(Pessoa entidade)
        {
            return new ValidadorPessoa().Validate(entidade);
        }

        protected override bool VerificarDuplicidade(string novoTexto)
        {
            var todos = SelecionarTodos();

            if (todos.Count != 0)
                return todos.Exists(x => x.Equals(novoTexto));

            return false;
        }

        #endregion
    }

}

