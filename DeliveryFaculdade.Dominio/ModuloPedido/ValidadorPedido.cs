using DeliveryFaculdade.Dominio.Compartilhado;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryFaculdade.Dominio.ModuloPedido
{
    public class ValidadorPedido : ValidadorBase<Pedido>
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
 
        }
    }
}
