using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_OfertasWebApi.Domains
{
    public partial class Pjuridica
    {
        public Pjuridica()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int IdPjuridica { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string NomeEmpresa { get; set; }
        public string EmailEmpresa { get; set; }
        public decimal Telefone { get; set; }
        public string Cnpj { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
