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

        public IRepositorioProduto repositorioProduto;
        public Produto Produto
        {
            get
            {
                return produto;

            }

            set
            {
                produto = value;
                txbPreco.Text = produto.Numero.ToString();
                txbNome.Text = produto.Nome;
                txbQuantidade.Text = produto.Quantidade.ToString();
                txbPreco.Text = produto.Preco.ToString("C");


            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

        }


    }
}
