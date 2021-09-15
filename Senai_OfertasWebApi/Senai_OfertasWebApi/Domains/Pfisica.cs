using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_OfertasWebApi.Domains
{
    public partial class Pfisica
    {
        public Pfisica()
        {
            Produtos = new HashSet<Produto>();
            Reservas = new HashSet<Reserva>();
        }

        public int IdPfisica { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public decimal Telefone { get; set; }
        public string Cpf { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
