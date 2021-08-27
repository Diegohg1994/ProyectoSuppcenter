using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoSuppcenter.Models
{
    public partial class Licencia
    {
        public Licencia()
        {
            Empresas = new HashSet<Empresa>();
            Suscripcions = new HashSet<Suscripcion>();
        }

        public string CodigoLic { get; set; }
        public string Nombre { get; set; }
        public string Descrpcion { get; set; }
        public decimal? PrecioCosto { get; set; }
        public decimal? PrecioVenta { get; set; }
        public int? IdFab { get; set; }

        public virtual Fabricante IdFabNavigation { get; set; }
        public virtual ICollection<Empresa> Empresas { get; set; }
        public virtual ICollection<Suscripcion> Suscripcions { get; set; }
    }
}
