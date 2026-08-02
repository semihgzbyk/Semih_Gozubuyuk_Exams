namespace Odev31_Constructor_CoffeeOrder.Models
{
    public class CoffeeOrder
    {
        // Auto-property'ler
        public string CustomerName { get; set; }
        public string CoffeeType { get; set; }
        public string Size { get; set; }
        public int SugarCount { get; set; }

        // 1. Constructor: Müşteri Adı ve Kahve Türü zorunlu, Boy varsayılan "Medium"
        public CoffeeOrder(string customerName, string coffeeType)
        {
            CustomerName = customerName;
            CoffeeType = coffeeType;
            Size = "Medium"; // Varsayılan boy
        }

        // 2. Constructor Overloading: Müşteri Adı, Kahve Türü ve Boy birlikte alınır
        public CoffeeOrder(string customerName, string coffeeType, string size)
        {
            CustomerName = customerName;
            CoffeeType = coffeeType;
            Size = size;
        }
    }
}