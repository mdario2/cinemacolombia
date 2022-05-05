using System;
using System.Collections.Generic;

#nullable disable

namespace RoyalFilms.Core.Entities
{
    public partial class PeliculasMulticine
    {
        public int IdPelicula { get; set; }
        public int IdMulticine { get; set; }
        public DateTime Horario { get; set; }
    }
}
