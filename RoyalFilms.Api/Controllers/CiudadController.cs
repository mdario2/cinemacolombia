using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RoyalFilms.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoyalFilms.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        private readonly IPeliculaRepository _peliculaRepository;

        public CiudadController(IPeliculaRepository peliculaRepository)
        {
            _peliculaRepository = peliculaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCiudades()
        {
            var ciudades = await _peliculaRepository.GetCiudades();
            return Ok(ciudades);
        }
    }
}
