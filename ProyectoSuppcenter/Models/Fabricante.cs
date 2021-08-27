using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoSuppcenter.Models
{
    public partial class Fabricante
    {
        public Fabricante()
        {
            Licencia = new HashSet<Licencia>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Licencia> Licencia { get; set; }
    }
}
