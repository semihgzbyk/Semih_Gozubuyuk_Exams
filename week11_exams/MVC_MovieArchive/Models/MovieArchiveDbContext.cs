using System;
using Microsoft.EntityFrameworkCore;
using MVC_MovieArchive.Models.Entities;

namespace MVC_MovieArchive.Models;

public class MovieArchiveDbContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql("Host=localhost;Port=12000;Database=mvc_db_moviearchive;Username=mvc;Password=postgres;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Movie>().HasData(
            new Movie { Id = 1, Title = "Babam ve Oğlum", Director = "Çağan Irmak", ReleaseYear = 2005 },
            new Movie { Id = 2, Title = "Eşkıya", Director = "Yavuz Turgul", ReleaseYear = 1996 },
            new Movie { Id = 3, Title = "Kış Uykusu", Director = "Nuri Bilge Ceylan", ReleaseYear = 2014 },
            new Movie { Id = 4, Title = "The Godfather", Director = "Francis Ford Coppola", ReleaseYear = 1972 },
            new Movie { Id = 5, Title = "Pulp Fiction", Director = "Quentin Tarantino", ReleaseYear = 1994 },
            new Movie { Id = 6, Title = "Inception", Director = "Christopher Nolan", ReleaseYear = 2010 },
            new Movie { Id = 7, Title = "Fight Club", Director = "David Fincher", ReleaseYear = 1999 },
            new Movie { Id = 8, Title = "Interstellar", Director = "Christopher Nolan", ReleaseYear = 2014 }
        );
    }
}