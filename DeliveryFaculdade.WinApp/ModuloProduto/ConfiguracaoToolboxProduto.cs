using DeliveryFaculdade.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryFaculdade.WinApp.ModuloProduto
{
    public class ConfiguracaoToolboxProduto : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Controle de Produtos";

        public override string TooltipInserir => "Inserir um novo Produto";

        public override string TooltipEditar => "Editar um Produto existente";

        public override string TooltipExcluir => "Excluir um Produto existente";
    }
}
