using DeliveryFaculdade.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryFaculdade.Dominio.ModuloProduto
{
    public class Produto : EntidadeBase<Produto>
    {
        public string Nome { get; set; }

        public string Preco { get; set; }

        public string Quantidade { get; set; }

        public Produto()
        {
                
        }

        public Produto(string nome, string preco, string quantidade)
        {
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;

        }

        public string ValorFormatado
        {
            
            get
            {
                return string.Format(CultureInfo.GetCultureInfo("pt-BR"), "US$ {0:#,###.##}", Preco);
            }
        }

        public override void Atualizar(Produto registro)
        {
            
        }
    }
}
