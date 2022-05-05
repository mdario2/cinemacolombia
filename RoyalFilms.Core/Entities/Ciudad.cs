using System;
using System.Collections.Generic;

#nullable disable

namespace RoyalFilms.Core.Entities
{
    public partial class Ciudad
    {
        public Ciudad()
        {
            Multicines = new HashSet<Multicine>();
        }

        public int IdCiudad { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Multicine> Multicines { get; set; }
    }
}
