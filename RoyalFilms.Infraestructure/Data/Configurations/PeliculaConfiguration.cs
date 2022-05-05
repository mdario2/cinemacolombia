using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RoyalFilms.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalFilms.Infraestructure.Data.Configurations
{
    public class PeliculaConfiguration : IEntityTypeConfiguration<Pelicula>
    {
        public void Configure(EntityTypeBuilder<Pelicula> builder)
        {
            throw new NotImplementedException();
        }
    }
}
