using AutoMapper;
using RoyalFilms.Core.DTOs;
using RoyalFilms.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalFilms.Infraestructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Pelicula, PeliculaDto>();
            CreateMap<PeliculaDto, Pelicula>();
        }
    }
}
