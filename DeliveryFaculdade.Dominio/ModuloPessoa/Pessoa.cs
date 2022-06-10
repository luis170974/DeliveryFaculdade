using DeliveryFaculdade.Dominio.Compartilhado;
using System;
using System.Collections.Generic;

namespace DeliveryFaculdade.Dominio.ModuloPessoa
{
    public class Pessoa : EntidadeBase<Pessoa>
    {
        public string Nome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Cpf { get; set; }

        public List<Estado> Estado { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

        public List<TipoPessoa> TipoDaPessoa { get; set; }

        public Pessoa()
        {

        }



        public override void Atualizar(Pessoa registro)
        {

        }
    }
}
