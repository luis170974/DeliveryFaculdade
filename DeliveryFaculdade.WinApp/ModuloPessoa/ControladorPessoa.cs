using DeliveryFaculdade.Dominio.ModuloPessoa;
using DeliveryFaculdade.Infra.BancoDados.ModuloPessoa;
using DeliveryFaculdade.WinApp.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryFaculdade.WinApp.ModuloPessoa
{
    public class ControladorPessoa : ControladorBase
    {
        private readonly RepositorioPessoaEmBancoDados repositorioPessoa;
        private TabelaPessoasControl tabelaPessoas;

        public ControladorPessoa(RepositorioPessoaEmBancoDados repositorioPessoa)
        {
            this.repositorioPessoa = repositorioPessoa;
        }

        public override void Inserir()
        {
            TelaCadastroPessoaForm tela = new TelaCadastroPessoaForm();
            tela.Pessoa = new();

            tela.GravarRegistro = repositorioPessoa.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarPessoas();
            }
        }



        public override void Editar()
        {
            Pessoa pessoaSelecionada = ObtemPessoaSelecionada();

            if (pessoaSelecionada == null)
            {
                MessageBox.Show("Selecione uma pessoa primeiro",
                "Edição de Pessoa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroPessoaForm tela = new TelaCadastroPessoaForm();

            tela.Pessoa = pessoaSelecionada;

            tela.GravarRegistro = repositorioPessoa.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarPessoas();
            }
        }



        public override void Excluir()
        {
            Pessoa pessoaSelecionada = ObtemPessoaSelecionada();

            if (pessoaSelecionada == null)
            {
                MessageBox.Show("Selecione uma pessoa primeiro",
                "Exclusão de Pessoa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a pessoa?",
                "Exclusão de Pessoa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorioPessoa.Excluir(pessoaSelecionada);
                CarregarPessoas();
            }
        }

        private Pessoa ObtemPessoaSelecionada()
        {
            var numeroPessoa = tabelaPessoas.ObtemNumeroPessoaSelecionada();

            return repositorioPessoa.Selecionar((int)numeroPessoa);
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxPessoa();
        }

        public override UserControl ObtemListagem()
        {
            if (tabelaPessoas == null)
                tabelaPessoas = new TabelaPessoasControl();

            CarregarPessoas();

            return tabelaPessoas;
        }


        private void CarregarPessoas()
        {
            List<Pessoa> pessoas = repositorioPessoa.SelecionarTodos();

                tabelaPessoas.AtualizarRegistros(pessoas);
                TelaPrincipalForm.Instancia.AtualizarRodape($"Visualizando {pessoas.Count} pessoa(s)");
            
        }
    }
}
