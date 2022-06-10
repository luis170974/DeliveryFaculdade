using DeliveryFaculdade.Dominio.ModuloPedido;
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

        public IRepositorioPesssoa repositorioPessoa;

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
                txtNumero.Text = pedido.Numero.ToString();
                lblPedido.Text = pedido.TipoPedido;
                lblValorPedido.Text = pedido.ValorPedido.ToString();
                
                
            }

        }




        private void btnTipoDelivery_Click(object sender, EventArgs e)
        {
            TelaCadastroItemPedidoForm tela = new TelaCadastroItemPedidoForm();

            tela.Show();

        }

        private void CarregarFuncionariosComboBox()
        {
            cmbAtendente.Items.Clear();

            List<Pessoa> pessoas = repositorioPessoa.SelecionarTodos();

            foreach (Pessoa p in pessoas)
            {
                cmbAtendente.Items.Add(p.TipoDaPessoa.Contains(TipoPessoa.Funcionario));
            }
        }

        private void CarregarPessoasComboBox()
        {
            cmbPessoa.Items.Clear();

            List<Pessoa> pessoas = repositorioPessoa.SelecionarTodos();

            foreach (Pessoa p in pessoas)
            {
                cmbAtendente.Items.Add(p.Nome);
            }
        }
    }
}
