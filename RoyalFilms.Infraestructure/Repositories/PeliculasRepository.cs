using Microsoft.EntityFrameworkCore;
using RoyalFilms.Core.Entities;
using RoyalFilms.Core.Interfaces;
using RoyalFilms.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalFilms.Infraestructure.Repositories
{
    public class PeliculasRepository : IPeliculaRepository
    {
        private readonly RoyalfilmsContext _context;
        public PeliculasRepository(RoyalfilmsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ciudad>> GetCiudades()
        {
            var ciudades = await _context.Ciudads.ToListAsync();
            return ciudades;
        }

        public async Task<Pelicula> GetPeliculas(int id)
        {
            var movies = await _context.Peliculas.FirstOrDefaultAsync(x => x.IdPelicula == id);
            return movies;
        }

        public async Task<IEnumerable<Pelicula>> GetPeliculasActivas()
        {
            var pelis = await _context.Peliculas.ToListAsync();

            var activas = (from p in pelis
                           where p.Estado == "Activa"
                           select p).ToList();

            //var activas = (from p in pelis
            //               where p.Genero == 4
            //               select p).ToList();


            return activas;
        }

        public async Task InsertPelicula(Pelicula peli)
        {
            _context.Peliculas.Add(peli);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePelicula(Pelicula peli)
        {
            var currentPelicula = await GetPeliculas(peli.IdPelicula);
            currentPelicula.Nombre = peli.Nombre;
            currentPelicula.Genero = peli.Genero;
            currentPelicula.Poster = peli.Poster;
            currentPelicula.Trailer = peli.Trailer;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeletePelicula(int id)
        {
            var currentPelicula = await GetPeliculas(id);
            _context.Peliculas.Remove(currentPelicula);

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
