using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_OfertasWebApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Pfisicas = new HashSet<Pfisica>();
            Pjuridicas = new HashSet<Pjuridica>();
            Produtos = new HashSet<Produto>();
            Reservas = new HashSet<Reserva>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Pfisica> Pfisicas { get; set; }
        public virtual ICollection<Pjuridica> Pjuridicas { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
