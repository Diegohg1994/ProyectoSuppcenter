using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoSuppcenter.Models
{
    public partial class Suscripcion
    {
        public int Id { get; set; }
        public string CodigoEmpresa { get; set; }
        public string CodigoLicencia { get; set; }
        public int? Asientos { get; set; }
        public DateTime? FechaGenerada { get; set; }
        public string Movimiento { get; set; }

        public virtual Empresa CodigoEmpresaNavigation { get; set; }
        public virtual Licencia CodigoLicenciaNavigation { get; set; }
    }
}
