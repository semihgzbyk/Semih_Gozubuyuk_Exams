using System;
using Microsoft.EntityFrameworkCore;
using MVC_Library.Models.Entities;

namespace MVC_Library.Models;

public class LibraryDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql("Host=localhost;Port=12000;Database=mvc_db_library;Username=mvc;Password=postgres;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>().HasData(
            new Book { Id = 1, Title = "Suç ve Ceza", Author = "Fyodor Dostoyevski", PageCount = 687 },
            new Book { Id = 2, Title = "1984", Author = "George Orwell", PageCount = 352 },
            new Book { Id = 3, Title = "Kürk Mantolu Madonna", Author = "Sabahattin Ali", PageCount = 160 },
            new Book { Id = 4, Title = "Dönüşüm", Author = "Franz Kafka", PageCount = 104 },
            new Book { Id = 5, Title = "Şeker Portakalı", Author = "José Mauro de Vasconcelos", PageCount = 184 },
            new Book { Id = 6, Title = "Simyacı", Author = "Paulo Coelho", PageCount = 188 },
            new Book { Id = 7, Title = "Küçük Prens", Author = "Antoine de Saint-Exupéry", PageCount = 112 },
            new Book { Id = 8, Title = "Sefiller", Author = "Victor Hugo", PageCount = 1724 }
        );
    }
}