namespace Odev22_Constructor_Product.Models
{
    public class Product
    {
        // Auto-property'ler
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        // Isim parametresini zorunlu kılan Constructor
        public Product(string name)
        {
            Name = name;
        }
    }
}