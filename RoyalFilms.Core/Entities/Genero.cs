using System;
using System.Collections.Generic;

#nullable disable

namespace RoyalFilms.Core.Entities
{
    public partial class Genero
    {
        public Genero()
        {
            Peliculas = new HashSet<Pelicula>();
        }

        public int IdGenero { get; set; }
        public string Nombre { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Pelicula> Peliculas { get; set; }
    }
}
