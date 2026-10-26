using System;
using Microsoft.EntityFrameworkCore;
using MVC_VetClinic.Models.Entities;

namespace MVC_VetClinic.Models;

public class VetClinicDbContext : DbContext
{
    public DbSet<Pet> Pets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql("Host=localhost;Port=12300;Database=vet_db;Username=vet_user;Password=vet_password;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Pet>().HasData(
            new Pet { Id = 1, Name = "Pamuk", Species = "Kedi", Age = 3 },
            new Pet { Id = 2, Name = "Karabaş", Species = "Köpek", Age = 5 },
            new Pet { Id = 3, Name = "Limon", Species = "Muhabbet Kuşu", Age = 2 },
            new Pet { Id = 4, Name = "Gece", Species = "Kedi", Age = 4 },
            new Pet { Id = 5, Name = "Max", Species = "Köpek", Age = 2 },
            new Pet { Id = 6, Name = "Fıstık", Species = "Tavşan", Age = 1 },
            new Pet { Id = 7, Name = "Duman", Species = "Kedi", Age = 6 },
            new Pet { Id = 8, Name = "Badem", Species = "Hamster", Age = 1 }
        );
    }
}