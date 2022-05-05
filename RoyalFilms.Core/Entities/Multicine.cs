using System;
using System.Collections.Generic;

#nullable disable

namespace RoyalFilms.Core.Entities
{
    public partial class Multicine
    {
        public int IdMulticine { get; set; }
        public string Nombre { get; set; }
        public int? Ciudad { get; set; }

        public virtual Ciudad CiudadNavigation { get; set; }
    }
}
