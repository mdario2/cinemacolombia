using RoyalFilms.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoyalFilms.Core.Interfaces
{
    public interface IPeliculaRepository
    {
        Task<IEnumerable<Pelicula>> GetPeliculasActivas();

        Task<IEnumerable<Ciudad>> GetCiudades();

        Task InsertPelicula(Pelicula peli);

        Task<bool> DeletePelicula(int id);

        Task<bool> UpdatePelicula(Pelicula peli);

    }
}
