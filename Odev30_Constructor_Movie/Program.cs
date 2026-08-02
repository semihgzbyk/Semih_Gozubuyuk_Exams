using System;
using Odev30_Constructor_Movie.Models;

namespace Odev30_Constructor_Movie
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Çift parametreli constructor (Süre varsayılan 120 dakika olacak)
            Movie movie1 = new Movie("Inception", "Christopher Nolan");
            movie1.Rating = 8.8;

            // 2. Üç parametreli constructor (Süre açıkça belirtiliyor)
            Movie movie2 = new Movie("Interstellar", "Christopher Nolan", 169);
            movie2.Rating = 8.7;

            Movie[] movies = { movie1, movie2 };

            Console.WriteLine("=== FİLM LİSTESİ ===\n");

            // Film bilgilerini, yönetmen ve süre detaylarını yazdırma
            foreach (Movie movie in movies)
            {
                Console.WriteLine($"Film Adı : {movie.Title}");
                Console.WriteLine($"Yönetmen : {movie.Director}");
                Console.WriteLine($"Süre     : {movie.DurationMinutes} dk");
                Console.WriteLine($"Puan     : {movie.Rating}");
                Console.WriteLine(new string('-', 35));
            }
        }
    }
}