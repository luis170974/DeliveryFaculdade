using DeliveryFaculdade.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryFaculdade.WinApp.ModuloPedido
{
    public class ConfiguracaoToolboxPedido : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Controle de Pedidos";

        public override string TooltipInserir => "Inserir um novo Pedido";

        public override string TooltipEditar => "Editar um Pedido existente";

        public override string TooltipExcluir => "Excluir um Pedido existente";

    }
}
