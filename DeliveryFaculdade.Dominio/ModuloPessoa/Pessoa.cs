using DeliveryFaculdade.Dominio.Compartilhado;
using System;
using System.Collections.Generic;

namespace DeliveryFaculdade.Dominio.ModuloPessoa
{
    public class Pessoa : EntidadeBase<Pessoa>
    {
        public string NomePessoa { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Cpf { get; set; }

        public string Estado { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

        public string TipoDoAcesso { get; set; }

        public string Logradouro { get; set; }

        public string NumeroCasa { get; set; }

        public Pessoa()
        {

        }

        public Pessoa(string nome, DateTime dataNascimento, string cpf, string estado, string telefone, string usuario, string senha, string tipoAcesso, string email, string logradouro, string numeroCasa)
        {
            NomePessoa = nome;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Estado = estado;
            Telefone = telefone;
            Email = email;
            Usuario = usuario;
            Senha = senha;
            TipoDoAcesso = tipoAcesso;
            Logradouro = logradouro;
            NumeroCasa = numeroCasa;
        }


        public string DataString
        {
            get
            {
                return DataNascimento.ToShortDateString();
            }
        }

        public override void Atualizar(Pessoa registro)
        {

        }
    }
}
