using DeliveryFaculdade.Dominio.ModuloPedido;
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
    public partial class TelaCadastroItemPedidoForm : Form
    {
        private readonly Pedido pedido;
        public TelaCadastroItemPedidoForm(Pedido pedido)
        {
            InitializeComponent();

            this.pedido = pedido;

            labelTipoPedido.Text = pedido.TipoPedido;

            foreach
        }


    }
}
