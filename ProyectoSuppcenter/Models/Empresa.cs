using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoSuppcenter.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            Suscripcions = new HashSet<Suscripcion>();
        }

        public string CodigoEmpresa { get; set; }
        public string NombreEm { get; set; }
        public string Contacto { get; set; }
        public string CedulaJuridica { get; set; }
        public string Correo { get; set; }
        public string IdLicencia { get; set; }

        public virtual Licencia IdLicenciaNavigation { get; set; }
        public virtual ICollection<Suscripcion> Suscripcions { get; set; }
    }
}
