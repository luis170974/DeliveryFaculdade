using DeliveryFaculdade.Dominio.ModuloPessoa;
using DeliveryFaculdade.Infra.Arquivos.ModuloPedido;
using DeliveryFaculdade.Infra.BancoDados.ModuloPessoa;
using DeliveryFaculdade.Infra.BancoDados.ModuloProduto;
using DeliveryFaculdade.WinApp.Compartilhado;
using DeliveryFaculdade.WinApp.ModuloPedido;
using DeliveryFaculdade.WinApp.ModuloPessoa;
using DeliveryFaculdade.WinApp.ModuloProduto;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DeliveryFaculdade.WinApp
{
    public partial class TelaPrincipalForm : Form
    {
        private ControladorBase controlador;
        private Dictionary<string, ControladorBase> controladores;


        public TelaPrincipalForm()
        {
            InitializeComponent();

            Instancia = this;

            labelRodape.Text = string.Empty;
            labelTipoCadastro.Text = string.Empty;



            InicializarControladores();
        }

        public static TelaPrincipalForm Instancia
        {
            get;
            private set;
        }

        public void AtualizarRodape(string mensagem)
        {
            labelRodape.Text = mensagem;
        }

        private void pedidosMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }

        private void produtosMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurarTelaPrincipal((ToolStripMenuItem)sender);
        }



        private void btnInserir_Click(object sender, EventArgs e)
        {
            controlador.Inserir();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            controlador.Editar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            controlador.Excluir();
        }


        private void ConfigurarBotoes(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.Enabled = configuracao.InserirHabilitado;
            btnEditar.Enabled = configuracao.EditarHabilitado;
            btnExcluir.Enabled = configuracao.ExcluirHabilitado;
        }

        private void ConfigurarTooltips(ConfiguracaoToolboxBase configuracao)
        {
            btnInserir.ToolTipText = configuracao.TooltipInserir;
            btnEditar.ToolTipText = configuracao.TooltipEditar;
            btnExcluir.ToolTipText = configuracao.TooltipExcluir;
        }

        private void ConfigurarTelaPrincipal(ToolStripMenuItem opcaoSelecionada)
        {
            var tipo = opcaoSelecionada.Text;

            controlador = controladores[tipo];

            ConfigurarToolbox();

            ConfigurarListagem();
        }

        private void ConfigurarToolbox()
        {
            ConfiguracaoToolboxBase configuracao = controlador.ObtemConfiguracaoToolbox();

            if (configuracao != null)
            {
                toolbox.Enabled = true;

                labelTipoCadastro.Text = configuracao.TipoCadastro;

                ConfigurarTooltips(configuracao);

                ConfigurarBotoes(configuracao);
            }
        }

        private void ConfigurarListagem()
        {
            AtualizarRodape("");

            var listagemControl = controlador.ObtemListagem();

            panelRegistros.Controls.Clear();

            listagemControl.Dock = DockStyle.Fill;

            panelRegistros.Controls.Add(listagemControl);
        }

        private void InicializarControladores()
        {
            var repositorioPedido = new RepositorioPedidoEmBancoDados();
  

            var repositorioPessoa = new RepositorioPessoaEmBancoDados();

            var repositorioProduto = new RepositorioProdutoEmBancoDados();

            controladores = new Dictionary<string, ControladorBase>();

            controladores.Add("Pedidos", new ControladorPedido(repositorioPedido, repositorioPessoa));
            controladores.Add("Produtos", new ControladorProduto(repositorioProduto));

        }


    }
}
