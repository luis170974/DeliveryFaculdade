using DeliveryFaculdade.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryFaculdade.WinApp.ModuloPessoa
{
    public class ConfiguracaoToolboxPessoa : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Controle de Pessoas";

        public override string TooltipInserir => "Inserir uma nova Pessoa";

        public override string TooltipEditar => "Editar uma nova Pessoa existente";

        public override string TooltipExcluir => "Excluir uma nova Pessoa existente";
    }
}
