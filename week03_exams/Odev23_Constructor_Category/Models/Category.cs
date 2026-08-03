namespace Odev23_Constructor_Category.Models
{
    public class Category
    {
        // Auto-property'ler
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // 1. Constructor: Sadece kategori adı zorunlu, açıklama varsayılan olarak boş
        public Category(string name)
        {
            Name = name;
            Description = "";
        }

        // 2. Constructor Overloading: Hem adı hem açıklamayı alır
        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}