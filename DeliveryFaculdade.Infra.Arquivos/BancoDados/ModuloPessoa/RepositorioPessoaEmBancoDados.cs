using DeliveryFaculdade.Dominio.ModuloPessoa;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryFaculdade.Infra.BancoDados.ModuloPessoa
{
    public class RepositorioPessoaEmBancoDados : IRepositorioPesssoa
    {
        public ValidationResult Editar(Pessoa registro)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Excluir(Pessoa registro)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Inserir(Pessoa novoRegistro)
        {
            throw new NotImplementedException();
        }

        public Pessoa SelecionarPorNumero(int numero)
        {
            throw new NotImplementedException();
        }

        public List<Pessoa> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
