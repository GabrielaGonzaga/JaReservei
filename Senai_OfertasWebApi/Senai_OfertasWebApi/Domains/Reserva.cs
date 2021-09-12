using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_OfertasWebApi.Domains
{
    public partial class Reserva
    {
        public int IdReserva { get; set; }
        public int? IdProduto { get; set; }
        public int? IdUsuario { get; set; }
        public int Quantidade { get; set; }
        public double PrecoTotal { get; set; }

        public virtual Produto IdProdutoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
