using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_OfertasWebApi.Domains
{
    public partial class Reserva
    {
        public int IdReserva { get; set; }
        public int? IdProduto { get; set; }
        public int? IdPfisica { get; set; }
        public int? IdPjuridica { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoTotal { get; set; }

        public virtual Pfisica IdPfisicaNavigation { get; set; }
        public virtual Pjuridica IdPjuridicaNavigation { get; set; }
        public virtual Produto IdProdutoNavigation { get; set; }
    }
}
