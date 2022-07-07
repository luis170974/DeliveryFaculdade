using DeliveryFaculdade.Dominio.ModuloPessoa;
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

namespace DeliveryFaculdade.WinApp.ModuloPessoa
{
    public partial class TabelaPessoasControl : UserControl
    {
        public TabelaPessoasControl()
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

                new DataGridViewTextBoxColumn { DataPropertyName = "NomePessoa", HeaderText = "Nome da Pessoa"},

                new DataGridViewTextBoxColumn { DataPropertyName = "DataString", HeaderText = "Data De Nascimento"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Cpf", HeaderText = "CPF da Pessoa"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Estado", HeaderText = "Estado"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Telefone", HeaderText = "Telefone"},

                new DataGridViewTextBoxColumn { DataPropertyName = "TipoDoAcesso", HeaderText = "TipoDoAcesso"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Logradouro", HeaderText = "Logradouro"},

                new DataGridViewTextBoxColumn { DataPropertyName = "NumeroCasa", HeaderText = "Numero da Casa"},


            };

            return colunas;
        }

        public void AtualizarRegistros(List<Pessoa> pessoas)
        {
            grid.DataSource = pessoas;
        }

        public object ObtemNumeroPessoaSelecionada()
        {
            return grid.SelecionarNumero<int>();
        }


    }
}
