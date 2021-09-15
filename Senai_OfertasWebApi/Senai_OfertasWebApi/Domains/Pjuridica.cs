using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_OfertasWebApi.Domains
{
    public partial class Pjuridica
    {
        public int IdPjuridica { get; set; }
        public int? IdUsuario { get; set; }
        public string Nome { get; set; }
        public string NomeEmpresa { get; set; }
        public string EmailEmpresa { get; set; }
        public decimal Telefone { get; set; }
        public string Cnpj { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
