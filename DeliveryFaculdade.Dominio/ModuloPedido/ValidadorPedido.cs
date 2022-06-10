using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryFaculdade.Dominio.ModuloPedido
{
    public class ValidadorPedido : AbstractValidator<Pedido>
    {
        public ValidadorPedido()
        {
            RuleFor(x => x.TipoPedido)
                .NotNull()
                .NotEmpty();


            RuleFor(x => x.Pessoa)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.ValorPedido)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.TipoDaPessoa)
             .NotNull()
             .NotEmpty();
 
        }
    }
}
