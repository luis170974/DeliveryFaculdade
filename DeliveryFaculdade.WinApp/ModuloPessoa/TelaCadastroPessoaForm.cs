using DeliveryFaculdade.Dominio.ModuloPessoa;
using DeliveryFaculdade.Dominio.ModuloProduto;
using DeliveryFaculdade.WinApp.Compartilhado;
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
                txtNumero.Text = pessoa.Id.ToString();
                txtNome.Text = pessoa.NomePessoa;
                txtCpf.Text = pessoa.Cpf;
                txtTelefone.Text = pessoa.Telefone;
                txtEmail.Text = pessoa.Email;
                txbData.Text = pessoa.DataNascimento.ToString();
                cmbEstado.Text = pessoa.Estado;
                cmbTipoAcesso.Text = pessoa.TipoDoAcesso;
                txtUsuario.Text = pessoa.Usuario;
                txtSenha.Text = pessoa.Senha;
                txtLogradouro.Text = pessoa.Logradouro;
                txtNumeroCasa.Text = pessoa.NumeroCasa;       


            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            pessoa.NomePessoa = txtNome.Text;
            pessoa.Cpf = txtCpf.Text;
            pessoa.Telefone = txtTelefone.Text;
            pessoa.Email = txtEmail.Text;
            pessoa.DataNascimento = Convert.ToDateTime(txbData.Text);
            pessoa.Estado = cmbEstado.Text;
            pessoa.TipoDoAcesso = cmbTipoAcesso.Text;
            pessoa.Usuario = txtUsuario.Text;
            pessoa.Senha = txtSenha.Text;
            pessoa.Logradouro = txtLogradouro.Text;
            pessoa.NumeroCasa = txtNumeroCasa.Text;

            ValidationResult resultadoValidacao = GravarRegistro(pessoa);

            if(resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }


        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            txtCpf.Clear();
            txtTelefone.Clear();
            txtEmail.Clear();
            txbData.Clear();
            cmbEstado.SelectedIndex = -1;
            cmbTipoAcesso.SelectedIndex = -1;
            txtUsuario.Clear();
            txtSenha.Clear();
            txtLogradouro.Clear();
            txtNumeroCasa.Clear();
        }

        private void TelaCadastroPessoa_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void txbNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = ValidadorCampos.ImpedirNumeroECharsEspeciaisTextBox(e);
        }

        private void txbSenha_TextChanged(object sender, EventArgs e)
        {
            txtSenha.PasswordChar = '*';
            txtSenha.MaxLength = 14;
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ValidarCampoEmail(e);
        }

        private void txbUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ValidarCampoLogin(e);
        }

        private void txbLogradouro_KeyPress(object sender, KeyPressEventArgs e)
        {
            e = ValidadorCampos.ImpedirNumeroECharsEspeciaisTextBox(e);
        }

        private void txbNumeroCasa_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ImpedirLetrasCharEspeciais(e);
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ImpedirLetrasCharEspeciais(e);
        }

        private void txtCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ImpedirLetrasCharEspeciais(e);
        }

        private void txbSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ImpedirCharEspeciais(e);
        }

        private void preencher_campos()
        {
            txtNome.Text = "Luis";
            txtCpf.Text = "09874430974";
            txtTelefone.Text = "49998319930";
            txtEmail.Text = "luishenriqueferreirakraus@hotmail.com";
            txbData.Text = "13/06/2002".ToString();
            cmbEstado.Text = "Santa Catarina";
            cmbTipoAcesso.Text = "Administrador";
            txtUsuario.Text = "luisin";
            txtSenha.Text = "123";
            txtLogradouro.Text = "ASASASS";
            txtNumeroCasa.Text = "402";
        }

        private void TelaCadastroPessoaForm_Load(object sender, EventArgs e)
        {
            preencher_campos();
        }
    }
}
