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
                new DataGridViewTextBoxColumn { DataPropertyName = "Numero", HeaderText = "Número"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Nome", HeaderText = "Nome da Pessoa"},

                new DataGridViewTextBoxColumn { DataPropertyName = "DataNascimento", HeaderText = "Data De Nascimento"},

                new DataGridViewTextBoxColumn { DataPropertyName = "Cpf", HeaderText = "CPF da Pessoa"},


            };

            return colunas;
        }

        public void AtualizarRegistros(List<Pessoa> pessoas)
        {
            grid.Rows.Clear();

            foreach (Pessoa pessoa in pessoas)
            {
                grid.Rows.Add(pessoa.Id, pessoa.Nome, pessoa.DataNascimento, pessoa.Cpf);
            }
        }

        public object ObtemNumeroPessoaSelecionada()
        {
            return grid.SelecionarNumero<int>();
        }


    }
}
