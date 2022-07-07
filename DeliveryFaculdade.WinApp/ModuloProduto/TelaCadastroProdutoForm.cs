using DeliveryFaculdade.Dominio.ModuloProduto;
using DeliveryFaculdade.Infra.BancoDados.ModuloProduto;
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

namespace DeliveryFaculdade.WinApp.ModuloProduto
{
    public partial class TelaCadastroProdutoForm : Form
    {
        public TelaCadastroProdutoForm()
        {
            InitializeComponent();
        }

        public Func<Produto, ValidationResult> GravarRegistro { get; set; }

        public List<Produto> produtos;

        public Produto produto;

        public RepositorioProdutoEmBancoDados repositorioProduto;
        public Produto Produto
        {
            get
            {
                return produto;

            }

            set
            {
                produto = value;
                txbNumero.Text = produto.Id.ToString();
                txbNome.Text = produto.Nome;
                txbQuantidade.Text = produto.Quantidade;
                txbPreco.Text = produto.Preco;


            }
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            produto.Nome = txbNome.Text;
            produto.Quantidade = txbQuantidade.Text;
            produto.Preco = txbPreco.Text;

            ValidationResult resultadoValidacao = GravarRegistro(produto);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txbNome.Clear();
            txbPreco.Clear();
            txbQuantidade.Clear();
        }



        private void txbQuantidade_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ImpedirLetrasCharEspeciais(e);
        }

        private void txbPreco_KeyPress(object sender, KeyPressEventArgs e)
        {
            ValidadorCampos.ImpedirLetrasCharEspeciais(e);
        }

        private void txbNome_KeyPress(object sender, KeyPressEventArgs e)
        { 
            e = ValidadorCampos.ImpedirNumeroECharsEspeciaisTextBox(e);
        }
    }
}
