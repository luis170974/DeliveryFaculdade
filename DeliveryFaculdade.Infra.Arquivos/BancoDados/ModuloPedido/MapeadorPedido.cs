using DeliveryFaculdade.Dominio.ModuloPedido;
using DeliveryFaculdade.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryFaculdade.Infra.BancoDados.ModuloPedido
{
    public class MapeadorPedido : MapeadorBase<Pedido>
    {
        public override void DefinirParametros(Pedido entidade, SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("ID", entidade.Id);
            cmd.Parameters.AddWithValue("TIPO_PEDIDO", entidade.TipoPedido);
            cmd.Parameters.AddWithValue("ID", entidade.Id);
        }

        public override void DefinirParametroValidacao(string campoBancoDados, Pedido entidade, SqlCommand cmd)
        {
            throw new NotImplementedException();
        }

        public override List<Pedido> LerTodos(SqlDataReader leitor)
        {
            throw new NotImplementedException();
        }

        public override Pedido LerUnico(SqlDataReader leitor)
        {
            throw new NotImplementedException();
        }
    }
}
