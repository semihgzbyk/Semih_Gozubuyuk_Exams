namespace Odev29_Constructor_Laptop.Models
{
    public class Laptop
    {
        // Auto-property'ler
        public string Brand { get; set; }
        public string Model { get; set; }
        public int RamGb { get; set; }
        public int StorageGb { get; set; }
        public decimal Price { get; set; }

        // 1. Constructor: Marka ve Model zorunlu
        public Laptop(string brand, string model)
        {
            Brand = brand;
            Model = model;
        }

        // 2. Constructor Overloading: Marka, Model, RAM ve Depolama birlikte alınır 
        public Laptop(string brand, string model, int ramGb, int storageGb)
        {
            Brand = brand;
            Model = model;
            RamGb = ramGb;
            StorageGb = storageGb;
        }
    }
}