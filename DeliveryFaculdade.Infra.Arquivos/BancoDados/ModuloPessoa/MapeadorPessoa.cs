using DeliveryFaculdade.Dominio.ModuloPessoa;
using DeliveryFaculdade.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryFaculdade.Infra.BancoDados.ModuloPessoa
{
    public class MapeadorPessoa : MapeadorBase<Pessoa>
    {
        public override void DefinirParametros(Pessoa entidade, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("ID", entidade.Id);
            cmd.Parameters.AddWithValue("NOME", entidade.Nome);
            cmd.Parameters.AddWithValue("DATANASCIMENTO", entidade.DataNascimento.ToShortDateString());
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

        public override void DefinirParametroValidacao(string campoBancoDados, Pessoa entidade, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue(campoBancoDados.ToUpper(), entidade.Nome);
        }

        public override List<Pessoa> LerTodos(SqlDataReader leitor)
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
                int numeroCasa = Convert.ToInt32(leitor["NUMEROCASA"]);


                Pessoa pessoa = new Pessoa(nome, dataNascimento,cpf,estado, telefone, usuario, senha,tipoAcesso, email, logradouro, numeroCasa)
                {
                    Id = id,
                    Estado = estado,
                    TipoDoAcesso = tipoAcesso,

                };

                pessoas.Add(pessoa);
            }

            return pessoas;
        }

        public override Pessoa LerUnico(SqlDataReader leitor)
        {
            Pessoa pessoa = null;

            if (leitor.Read())
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
                int numeroCasa = Convert.ToInt32(leitor["NUMEROCASA"]);


                pessoa = new Pessoa(nome, dataNascimento, cpf, estado, telefone, usuario, senha, tipoAcesso, email, logradouro, numeroCasa)
                {
                    Id = id,
                    Estado = estado,
                    TipoDoAcesso = tipoAcesso,

                };

            }

            return pessoa;
        }
    }
}
