using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoSuppcenter.Models
{
    public partial class Accione
    {
        public Accione()
        {
            Audioria = new HashSet<Audiorium>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Audiorium> Audioria { get; set; }
    }
}
