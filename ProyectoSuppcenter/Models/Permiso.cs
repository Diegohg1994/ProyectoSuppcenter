using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoSuppcenter.Models
{
    public partial class Permiso
    {
        public int Id { get; set; }
        public bool? EmAg { get; set; }
        public bool? EmMo { get; set; }
        public bool? EmEl { get; set; }
        public bool? EmVis { get; set; }
        public bool? LicAg { get; set; }
        public bool? LicMo { get; set; }
        public bool? LicEl { get; set; }
        public bool? LicVis { get; set; }
        public bool? SusAg { get; set; }
        public bool? SusMo { get; set; }
        public bool? SusEl { get; set; }
        public bool? SusVis { get; set; }
        public bool? PorVis { get; set; }
        public bool? PorEdit { get; set; }

        public virtual Usuario IdNavigation { get; set; }
    }
}
