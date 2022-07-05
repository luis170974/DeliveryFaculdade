using DeliveryFaculdade.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryFaculdade.Infra.BancoDados.Compartilhado
{
    public abstract class MapeadorBase<T> where T : EntidadeBase<T>
    {
        public abstract List<T> LerTodos(SqlDataReader leitor);

        public abstract T LerUnico(SqlDataReader leitor);

        public abstract void DefinirParametros(T entidade, SqlCommand cmd);

        public abstract void DefinirParametroValidacao(string campoBancoDados, T entidade, SqlCommand cmd);
    }
}
