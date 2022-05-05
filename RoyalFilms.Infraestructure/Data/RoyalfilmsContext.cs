using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RoyalFilms.Core.Entities;

#nullable disable

namespace RoyalFilms.Infraestructure.Data
{
    public partial class RoyalfilmsContext : DbContext
    {
        public RoyalfilmsContext()
        {
        }

        public RoyalfilmsContext(DbContextOptions<RoyalfilmsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ciudad> Ciudads { get; set; }
        public virtual DbSet<Genero> Generos { get; set; }
        public virtual DbSet<Multicine> Multicines { get; set; }
        public virtual DbSet<Pelicula> Peliculas { get; set; }
        public virtual DbSet<PeliculasMulticine> PeliculasMulticines { get; set; }
        public virtual DbSet<PgBuffercache> PgBuffercaches { get; set; }
        public virtual DbSet<PgStatStatement> PgStatStatements { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pg_buffercache")
                .HasPostgresExtension("pg_stat_statements");

            modelBuilder.Entity<Ciudad>(entity =>
            {
                entity.HasKey(e => e.IdCiudad)
                    .HasName("ciudad_pkey");

                entity.ToTable("ciudad");

                entity.Property(e => e.IdCiudad).HasColumnName("id_ciudad");

                entity.Property(e => e.Estado)
                    .HasMaxLength(40)
                    .HasColumnName("estado")
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(e => e.IdGenero)
                    .HasName("genero_pkey");

                entity.ToTable("genero");

                entity.Property(e => e.IdGenero).HasColumnName("id_genero");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("estado")
                    .IsFixedLength(true);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasColumnName("nombre")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Multicine>(entity =>
            {
                entity.HasKey(e => e.IdMulticine)
                    .HasName("multicine_pkey");

                entity.ToTable("multicine");

                entity.HasIndex(e => e.Ciudad, "fki_CiudadMulticine_FK");

                entity.Property(e => e.IdMulticine).HasColumnName("id_multicine");

                entity.Property(e => e.Ciudad).HasColumnName("ciudad");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("nombre")
                    .IsFixedLength(true);

                entity.HasOne(d => d.CiudadNavigation)
                    .WithMany(p => p.Multicines)
                    .HasForeignKey(d => d.Ciudad)
                    .HasConstraintName("CiudadMulticine_FK");
            });

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.HasKey(e => e.IdPelicula)
                    .HasName("peliculas_pkey");

                entity.ToTable("peliculas");

                entity.HasIndex(e => e.Genero, "fki_GeneroPeliculas_FK");

                entity.Property(e => e.IdPelicula).HasColumnName("id_pelicula");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(40)
                    .HasColumnName("estado")
                    .IsFixedLength(true);

                entity.Property(e => e.Genero).HasColumnName("genero");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("nombre")
                    .IsFixedLength(true);

                entity.Property(e => e.Poster)
                    .HasMaxLength(100)
                    .HasColumnName("poster")
                    .IsFixedLength(true);

                entity.Property(e => e.Trailer)
                    .HasMaxLength(100)
                    .HasColumnName("trailer")
                    .IsFixedLength(true);

                entity.HasOne(d => d.GeneroNavigation)
                    .WithMany(p => p.Peliculas)
                    .HasForeignKey(d => d.Genero)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("GeneroPeliculas_FK");
            });

            modelBuilder.Entity<PeliculasMulticine>(entity =>
            {
                entity.HasKey(e => new { e.IdPelicula, e.IdMulticine })
                    .HasName("peliculas_multicines_pkey");

                entity.ToTable("peliculas_multicines");

                entity.Property(e => e.IdPelicula).HasColumnName("id_pelicula");

                entity.Property(e => e.IdMulticine).HasColumnName("id_multicine");

                entity.Property(e => e.Horario)
                    .HasColumnType("timestamp with time zone")
                    .HasColumnName("horario");
            });

            modelBuilder.Entity<PgBuffercache>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pg_buffercache");

                entity.Property(e => e.Bufferid).HasColumnName("bufferid");

                entity.Property(e => e.Isdirty).HasColumnName("isdirty");

                entity.Property(e => e.PinningBackends).HasColumnName("pinning_backends");

                entity.Property(e => e.Relblocknumber).HasColumnName("relblocknumber");

                entity.Property(e => e.Reldatabase)
                    .HasColumnType("oid")
                    .HasColumnName("reldatabase");

                entity.Property(e => e.Relfilenode)
                    .HasColumnType("oid")
                    .HasColumnName("relfilenode");

                entity.Property(e => e.Relforknumber).HasColumnName("relforknumber");

                entity.Property(e => e.Reltablespace)
                    .HasColumnType("oid")
                    .HasColumnName("reltablespace");

                entity.Property(e => e.Usagecount).HasColumnName("usagecount");
            });

            modelBuilder.Entity<PgStatStatement>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pg_stat_statements");

                entity.Property(e => e.BlkReadTime).HasColumnName("blk_read_time");

                entity.Property(e => e.BlkWriteTime).HasColumnName("blk_write_time");

                entity.Property(e => e.Calls).HasColumnName("calls");

                entity.Property(e => e.Dbid)
                    .HasColumnType("oid")
                    .HasColumnName("dbid");

                entity.Property(e => e.LocalBlksDirtied).HasColumnName("local_blks_dirtied");

                entity.Property(e => e.LocalBlksHit).HasColumnName("local_blks_hit");

                entity.Property(e => e.LocalBlksRead).HasColumnName("local_blks_read");

                entity.Property(e => e.LocalBlksWritten).HasColumnName("local_blks_written");

                entity.Property(e => e.MaxTime).HasColumnName("max_time");

                entity.Property(e => e.MeanTime).HasColumnName("mean_time");

                entity.Property(e => e.MinTime).HasColumnName("min_time");

                entity.Property(e => e.Query).HasColumnName("query");

                entity.Property(e => e.Queryid).HasColumnName("queryid");

                entity.Property(e => e.Rows).HasColumnName("rows");

                entity.Property(e => e.SharedBlksDirtied).HasColumnName("shared_blks_dirtied");

                entity.Property(e => e.SharedBlksHit).HasColumnName("shared_blks_hit");

                entity.Property(e => e.SharedBlksRead).HasColumnName("shared_blks_read");

                entity.Property(e => e.SharedBlksWritten).HasColumnName("shared_blks_written");

                entity.Property(e => e.StddevTime).HasColumnName("stddev_time");

                entity.Property(e => e.TempBlksRead).HasColumnName("temp_blks_read");

                entity.Property(e => e.TempBlksWritten).HasColumnName("temp_blks_written");

                entity.Property(e => e.TotalTime).HasColumnName("total_time");

                entity.Property(e => e.Userid)
                    .HasColumnType("oid")
                    .HasColumnName("userid");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
