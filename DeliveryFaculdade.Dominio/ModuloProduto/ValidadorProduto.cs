using DeliveryFaculdade.Dominio.Compartilhado;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryFaculdade.Dominio.ModuloProduto
{
    public class ValidadorProduto : ValidadorBase<Produto>
    {
        public ValidadorProduto()
        {
            RuleFor(x => x.Nome)
                    .NotEmpty()
                    .NotNull();

            RuleFor(x => x.Preco)
                    .NotEmpty()
                    .NotNull();
        }
    }
}
