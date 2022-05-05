using System;
using System.Collections.Generic;

#nullable disable

namespace RoyalFilms.Core.Entities
{
    public partial class Pelicula
    {
        public int IdPelicula { get; set; }
        public string Nombre { get; set; }
        public int Genero { get; set; }
        public string Poster { get; set; }
        public string Trailer { get; set; }
        public string Estado { get; set; }

        public virtual Genero GeneroNavigation { get; set; }
    }
}
