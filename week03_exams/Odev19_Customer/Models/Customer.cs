using System;

namespace Odev19_Customer.Models
{
    public class Customer
    {
        // Auto-property'ler
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public DateTime BirthDate { get; set; }
    }
}