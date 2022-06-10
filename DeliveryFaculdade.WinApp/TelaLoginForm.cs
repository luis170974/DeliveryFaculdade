using DeliveryFaculdade.Infra.Arquivos.ModuloPedido;
using DeliveryFaculdade.Infra.BancoDados.ModuloPessoa;
using DeliveryFaculdade.WinApp.Compartilhado;
using DeliveryFaculdade.WinApp.ModuloPedido;
using DeliveryFaculdade.WinApp.ModuloPessoa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeliveryFaculdade.WinApp
{
    public partial class TelaLoginForm : Form
    {
        public TelaLoginForm()
        {
            InitializeComponent();
        }

        private const string enderecoBanco =
        @"Data Source=(LocalDB)\MSSqlLocalDB;
       Initial Catalog=deliveryFaculdadeDb;
       Integrated Security=True;
       Pooling=False";

        string sql = @"SELECT 
	            NUMERO,
				USUARIO,
				SENHA


            FROM
	            TBPESSOA";


        private void btnEntrar_Click(object sender, EventArgs e)
        {
            LogarUsuario();

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            TelaCadastroPessoaForm tela = new TelaCadastroPessoaForm();

            tela.Show();
        }

        private void LogarUsuario()
        {
            SqlConnection conexaoComBanco = null;
            SqlDataReader reader = null;



            try
            {
                conexaoComBanco = new SqlConnection(enderecoBanco);

                conexaoComBanco.Open();

                var cmd = new SqlCommand(sql, conexaoComBanco);

                cmd.Parameters.AddWithValue("@USUARIO", txtLogin.Text);
                cmd.Parameters.AddWithValue("@SENHA", txtSenha.Text);

                reader = cmd.ExecuteReader();



                if (reader.Read())
                {

                    if (txtLogin.Text.Equals(reader["USUARIO"].ToString()) && txtSenha.Text.Equals(reader["SENHA"].ToString()))
                    {

                        MessageBox.Show("Login efetuado com sucesso", "Parabéns", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        var telaMenu = new TelaPrincipalForm();

                        telaMenu.Show();
                    }
                }

                else
                {
                    MessageBox.Show("Usuário e senha não confere.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
             



        }

            finally
            {
                if (reader != null)
                    reader.Close();

                if (conexaoComBanco != null)
                    conexaoComBanco.Close();
            }
        }



    }
}



