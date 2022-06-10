using DeliveryFaculdade.Dominio.ModuloProduto;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryFaculdade.Infra.BancoDados.ModuloProduto
{
    public class RepositorioProdutoEmBancoDados : IRepositorioProduto
    {

        public ValidationResult Inserir(Produto novoRegistro)
        {
            throw new NotImplementedException();
        }
        public ValidationResult Editar(Produto registro)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Excluir(Produto registro)
        {
            throw new NotImplementedException();
        }



        public Produto SelecionarPorNumero(int numero)
        {
            throw new NotImplementedException();
        }

        public List<Produto> SelecionarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
