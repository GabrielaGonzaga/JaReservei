using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_OfertasWebApi.Domains
{
    public partial class Produto
    {
        public Produto()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int IdProduto { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdTipoProduto { get; set; }
        public string NomeProduto { get; set; }
        public string LinkProduto { get; set; }
        public string ImagemProduto { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }

        public virtual TipoProduto IdTipoProdutoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
