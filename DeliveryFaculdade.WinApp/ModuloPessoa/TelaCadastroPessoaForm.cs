using DeliveryFaculdade.Dominio.ModuloPessoa;
using DeliveryFaculdade.Dominio.ModuloProduto;
using FluentValidation.Results;
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
    public partial class TelaCadastroPessoaForm : Form
    {
        public TelaCadastroPessoaForm()
        {
            InitializeComponent();
            
        }

        public Func<Pessoa, ValidationResult> GravarRegistro { get; set; }

        public List<Pessoa> pessoas;


        private Pessoa pessoa;


        public Pessoa Pessoa
        {
            get
            {
                return pessoa;

            }

            set
            {
                pessoa = value;
                txtNumero.Text = pessoa.Numero.ToString();
                txtNome.Text = pessoa.Nome;
                txtCpf.Text = pessoa.Cpf;
                txtTelefone.Text = pessoa.Telefone;
                txtEmail.Text = pessoa.Email;
                dtpDataNascimento.Value = pessoa.DataNascimento;
                cmbEstado.SelectedItem = pessoa.Estado;
                cmbFunção.SelectedItem = pessoa.TipoDaPessoa;


            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
