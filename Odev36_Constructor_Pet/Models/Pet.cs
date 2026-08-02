namespace Odev36_Constructor_Pet.Models
{
    public class Pet
    {
        // Auto-property'ler
        public string Name { get; set; }
        public string Type { get; set; }
        public int Age { get; set; }
        public string OwnerName { get; set; }

        // 1. Constructor: Ad ve Sahibi zorunlu, Tür varsayılan "Unknown"
        public Pet(string name, string ownerName)
        {
            Name = name;
            OwnerName = ownerName;
            Type = "Unknown"; // Varsayılan tür
        }

        // 2. Constructor Overloading: Ad, Sahibi, Tür ve Yaş birlikte alınır
        public Pet(string name, string ownerName, string type, int age)
        {
            Name = name;
            OwnerName = ownerName;
            Type = type;
            Age = age;
        }
    }
}