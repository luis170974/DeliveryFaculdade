using DeliveryFaculdade.Dominio.ModuloPedido;
using DeliveryFaculdade.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryFaculdade.WinApp.ModuloPedido
{
    public partial class TabelaPedidosControl : UserControl
    {
        public TabelaPedidosControl()
        {
            InitializeComponent();
            grid.ConfigurarGridSomenteLeitura();
            grid.ConfigurarGridZebrado();
            grid.Columns.AddRange(ObterColunas());
        }

        private DataGridViewColumn[] ObterColunas()
        {
            var colunas = new DataGridViewColumn[]
            {
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { DataPropertyName = "TipoPedido", HeaderText = "Nome do pedido"},

                new DataGridViewTextBoxColumn { DataPropertyName = "DataPedido", HeaderText = "Data do Pedido"},

                new DataGridViewTextBoxColumn { DataPropertyName = "ValorPedido", HeaderText = "Valor"},

                new DataGridViewTextBoxColumn { DataPropertyName = "TipoDaPessoa", HeaderText = "Tipo Da Pessoa"},

            };

            return colunas;
        }

        public void AtualizarRegistros(List<Pedido> pedidos)
        {
            grid.Rows.Clear();

            foreach (Pedido pedido in pedidos)
            {
                grid.Rows.Add(pedido.Numero, pedido.TipoPedido, pedido.DataDoPedido, pedido.ValorPedido, pedido.TipoDaPessoa);
            }
        }

        public object ObtemNumeroMateriaSelecionada()
        {
            return grid.SelecionarNumero<int>();
        }
    }
}
