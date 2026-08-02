namespace Odev30_Constructor_Movie.Models
{
    public class Movie
    {
        // Auto-property'ler
        public string Title { get; set; }
        public string Director { get; set; }
        public int DurationMinutes { get; set; }
        public double Rating { get; set; }

        // 1. Constructor: Film Adı ve Yönetmen zorunlu, Süre varsayılan 120 dk
        public Movie(string title, string director)
        {
            Title = title;
            Director = director;
            DurationMinutes = 120; // Varsayılan süre
        }

        // 2. Constructor Overloading: Ad, Yönetmen ve Süre birlikte alınır 
        public Movie(string title, string director, int durationMinutes)
        {
            Title = title;
            Director = director;
            DurationMinutes = durationMinutes;
        }
    }
}