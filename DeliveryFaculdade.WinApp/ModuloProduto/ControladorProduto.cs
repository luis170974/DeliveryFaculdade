
using DeliveryFaculdade.Dominio.ModuloProduto;
using DeliveryFaculdade.Infra.BancoDados.ModuloProduto;
using DeliveryFaculdade.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryFaculdade.WinApp.ModuloProduto
{
    public class ControladorProduto : ControladorBase
    {
        private readonly RepositorioProdutoEmBancoDados repositorioProduto;
        private TabelaProdutosControl tabelaProdutos;

        public ControladorProduto(RepositorioProdutoEmBancoDados repositorioProduto)
        {
            this.repositorioProduto = repositorioProduto;
        }

        public override void Inserir()
        {
            TelaCadastroProdutoForm tela = new TelaCadastroProdutoForm();
            tela.Produto = new();

            tela.GravarRegistro = repositorioProduto.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarProduto();
            }
        }

        public override void Editar()
        {
            Produto produtoSelecionado = ObtemProdutoSelecionado();

            if (produtoSelecionado == null)
            {
                MessageBox.Show("Selecione um Produto primeiro",
                "Exclusão de Produto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroProdutoForm tela = new TelaCadastroProdutoForm();

            tela.Produto = produtoSelecionado;

            tela.GravarRegistro = repositorioProduto.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarProduto();
            }
        }

        public override void Excluir()
        {
            Produto produtoSelecionado = ObtemProdutoSelecionado();

            if (produtoSelecionado == null)
            {
                MessageBox.Show("Selecione um Produto primeiro",
                "Exclusão de Produto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Produto?",
                "Exclusão de Produto", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioProduto.Excluir(produtoSelecionado);
                CarregarProduto();
            }
        }

        private Produto ObtemProdutoSelecionado()
        {
                var numeroProduto = tabelaProdutos.ObtemNumeroProdutoSelecionado();

                return repositorioProduto.SelecionarUnico((int)numeroProduto);
            
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxProduto();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaProdutos == null)
                tabelaProdutos = new TabelaProdutosControl();

            CarregarProduto();

            return tabelaProdutos;
        }

        private void CarregarProduto()
        {
            List<Produto> produtos = repositorioProduto.SelecionarTodos();

            tabelaProdutos.AtualizarRegistros(produtos);
            TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {produtos.Count} pessoa(s) {produtos}");
        }
    }
}
