using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_OfertasWebApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Produtos = new HashSet<Produto>();
            Reservas = new HashSet<Reserva>();
        }

        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public decimal Telefone { get; set; }
        public decimal? CPF { get; set; }
        public decimal? CNPJ { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
