using DeliveryFaculdade.Dominio.ModuloPedido;
using DeliveryFaculdade.Dominio.ModuloPessoa;
using DeliveryFaculdade.Dominio.ModuloProduto;
using DeliveryFaculdade.Infra.BancoDados.Compartilhado;
using DeliveryFaculdade.Infra.BancoDados.ModuloPessoa;
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

namespace DeliveryFaculdade.WinApp.ModuloPedido
{
    public partial class TelaCadastroPedidoForm : Form
    {
        
        

        public TelaCadastroPedidoForm()
        {
            InitializeComponent();
            

        }



        public Func<Pedido, ValidationResult> GravarRegistro { get; set; }

        public List<Pessoa> pessoas;

        public RepositorioPessoaEmBancoDados repositorioPessoa;

        private Pedido pedido;


        public List<Produto> produtos;
        public Pedido Pedido
        {
            get 
            { 
                return pedido; 

            }

            set
            {
                pedido = value;
                txtNumero.Text = pedido.Id.ToString();
                lblValorPedido.Text = pedido.ValorPedido.ToString();
                
                
            }

        }




        private void btnTipoDelivery_Click(object sender, EventArgs e)
        {
            TelaCadastroItemPedidoForm tela = new TelaCadastroItemPedidoForm();

            tela.Show();

        }

        private void CarregarPessoasComboBox()
        {
            cmbPessoa.Items.Clear();

            List<Pessoa> pessoas = repositorioPessoa.SelecionarTodos();

            foreach (Pessoa p in pessoas)
            {
                cmbPessoa.Items.Add(p.Nome);
            }
        }
    }
}
