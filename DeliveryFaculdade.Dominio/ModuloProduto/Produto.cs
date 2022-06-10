using DeliveryFaculdade.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryFaculdade.Dominio.ModuloProduto
{
    public class Produto : EntidadeBase<Produto>
    {
        public string Nome { get; set; }

        public float Preco { get; set; }

        public int Quantidade { get; set; }

        public Produto()
        {
                
        }

        public override void Atualizar(Produto registro)
        {
            
        }
    }
}
