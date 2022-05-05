using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalFilms.Core.DTOs
{
    public class PeliculaDto
    {
        public int IdPelicula { get; set; }
        public string Nombre { get; set; }
        public int Genero { get; set; }
        public string Poster { get; set; }
        public string Trailer { get; set; }
        public string Estado { get; set; }
    }
}
