using DeliveryFaculdade.Dominio.ModuloProduto;
using DeliveryFaculdade.Infra.BancoDados.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryFaculdade.Infra.BancoDados.ModuloProduto
{
    public class MapeadorProduto : MapeadorBase<Produto>
    {
        public override void DefinirParametros(Produto entidade, SqlCommand cmd)
        {
            throw new NotImplementedException();
        }

        public override void DefinirParametroValidacao(string campoBancoDados, Produto entidade, SqlCommand cmd)
        {
            throw new NotImplementedException();
        }

        public override List<Produto> LerTodos(SqlDataReader leitor)
        {
            throw new NotImplementedException();
        }

        public override Produto LerUnico(SqlDataReader leitor)
        {
            throw new NotImplementedException();
        }
    }
}
