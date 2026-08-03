namespace Odev16_MenuItem.Models
{
    public class MenuItem
    {
        // Auto-property'ler
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public bool IsVegetarian { get; set; }
    }
}