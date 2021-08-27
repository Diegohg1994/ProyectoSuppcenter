using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoSuppcenter.Models
{
    public partial class Audiorium
    {
        public int Id { get; set; }
        public int? Idusuario { get; set; }
        public int? Accion { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Accione AccionNavigation { get; set; }
        public virtual Usuario IdusuarioNavigation { get; set; }
    }
}
