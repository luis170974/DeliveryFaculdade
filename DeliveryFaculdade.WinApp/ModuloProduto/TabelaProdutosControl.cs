using DeliveryFaculdade.Dominio.ModuloProduto;
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

namespace DeliveryFaculdade.WinApp.ModuloProduto
{
    public partial class TabelaProdutosControl : UserControl
    {
        public TabelaProdutosControl()
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
                new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome do Produto"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Preco", HeaderText = "Preço"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Quantidade", HeaderText = "Quantidade no estoque"},


            };

            return colunas;
        }

        public void AtualizarRegistros(List<Produto> produtos)
        {
            grid.DataSource = produtos;
        }

        public object ObtemNumeroProdutoSelecionado()
        {
            return grid.SelecionarNumero<int>();
        }
    }
}
