using DeliveryFaculdade.Dominio.ModuloPedido;
using DeliveryFaculdade.Dominio.ModuloPessoa;
using DeliveryFaculdade.WinApp.Compartilhado;
using DeliveryFaculdade.WinApp.ModuloPessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryFaculdade.WinApp.ModuloPedido
{
    public class ControladorPedido : ControladorBase
    {
        private readonly IRepositorioPedido repositorioPedido;
        private readonly IRepositorioPesssoa repositorioPessoa;
        private TabelaPedidosControl tabelaPedidos;

        public ControladorPedido(IRepositorioPedido repositorioPedido, IRepositorioPesssoa repositorio)
        {
            this.repositorioPedido = repositorioPedido;
            this.repositorioPessoa = repositorio;

        }

        public override void Inserir()
        {
            TelaCadastroPedidoForm tela = new TelaCadastroPedidoForm();
            tela.Pedido = new Pedido();

            tela.GravarRegistro = repositorioPedido.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarPedidos();
            }
        }



        public override void Editar()
        {
            Pedido pedidoSelecionado = ObtemPedidoSelecionado();

            if (pedidoSelecionado == null)
            {
                MessageBox.Show("Selecione um pedido primeiro",
                "Edição de Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroPedidoForm tela = new TelaCadastroPedidoForm();

            tela.Pedido = pedidoSelecionado;

            tela.GravarRegistro = repositorioPedido.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarPedidos();
            }
        }



        public override void Excluir()
        {
            Pedido pedidoSelecionado = ObtemPedidoSelecionado();

            if (pedidoSelecionado == null)
            {
                MessageBox.Show("Selecione um pedido primeiro",
                "Exclusão de Pedidos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o pedido?",
                "Exclusão de Pedidos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioPedido.Excluir(pedidoSelecionado);
                CarregarPedidos();
            }
        }

        private void CarregarPedidos()
        {
            List<Pedido> pedidos = repositorioPedido.SelecionarTodos();

            tabelaPedidos.AtualizarRegistros(pedidos);
            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {pedidos.Count} pedido(s) {pedidos}");
        }

        private Pedido ObtemPedidoSelecionado()
        {
            throw new NotImplementedException();
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxPedido();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaPedidos == null)
                tabelaPedidos = new TabelaPedidosControl();

            CarregarPedidos();

            return tabelaPedidos;
        }
    }
}
