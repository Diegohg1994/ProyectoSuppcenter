using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoSuppcenter.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Audioria = new HashSet<Audiorium>();
        }

        public int Id { get; set; }
        public string Usuario1 { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public int? IdRol { get; set; }

        public virtual Role IdRolNavigation { get; set; }
        public virtual Permiso Permiso { get; set; }
        public virtual ICollection<Audiorium> Audioria { get; set; }
    }
}
