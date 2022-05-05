using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoyalFilms.Core.DTOs;
using RoyalFilms.Core.Entities;
using RoyalFilms.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoyalFilms.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly IPeliculaRepository _peliculaRepository;
        private readonly IMapper _mapper; 

        public PeliculasController(IPeliculaRepository peliculaRepository,IMapper mapper)
        {
            _peliculaRepository = peliculaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPeliculasActivas()
        {
            var pelis = await _peliculaRepository.GetPeliculasActivas();
            /*Usando Automapper*/
            var pelisDto = _mapper.Map<IEnumerable<PeliculaDto>>(pelis);


            /*SIN AUTOMAPPER*/
            //var pelisDto = pelis.Select(x => new PeliculaDto
            //{
            //    IdPelicula = x.IdPelicula,
            //    Nombre = x.Nombre,
            //    Genero = x.Genero,
            //    Poster = x.Poster,
            //    Trailer = x.Trailer,
            //    Estado = x.Estado
            //});
            return Ok(pelisDto);
        }

        [HttpPost]
        public async Task<IActionResult> PostPeliculas(PeliculaDto pelidto)
        {
            var peli = _mapper.Map<Pelicula>(pelidto);

            await _peliculaRepository.InsertPelicula(peli);
            return Ok(peli);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, PeliculaDto pelidto)
        {
            var peli = _mapper.Map<Pelicula>(pelidto);
            peli.IdPelicula = id;

            await _peliculaRepository.UpdatePelicula(peli);
            return Ok(peli);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
           var result = await _peliculaRepository.DeletePelicula(id);
           return Ok(result);
        }

    }
}
