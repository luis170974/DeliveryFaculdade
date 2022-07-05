using DeliveryFaculdade.Dominio.Compartilhado;
using DeliveryFaculdade.Dominio.ModuloPessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryFaculdade.Dominio.ModuloPedido
{
    public class Pedido : EntidadeBase<Pedido>
    {
        public string TipoPedido { get; set; }

        public int ValorPedido { get; set; }
        
        public Pessoa Pessoa { get; set; }

        public DateTime DataDoPedido { get; set; }

        public Pedido()
        {
            DataDoPedido = DateTime.Now;
        }



        public override void Atualizar(Pedido registro)
        {
            Id = registro.Id;
            TipoPedido = registro.TipoPedido;
            ValorPedido = registro.ValorPedido;
            Pessoa = registro.Pessoa;
            DataDoPedido = registro.DataDoPedido;
        }
    }
}
