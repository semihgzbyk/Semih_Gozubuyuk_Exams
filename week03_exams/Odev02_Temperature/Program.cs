using System;
using Odev02_Temperature.Models;

namespace Odev02_Temperature
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SICAKLIK DÖNÜŞTÜRÜCÜ (TEMPERATURE) ===\n");

            // Test edilecek Celsius değerleri dizisi
            double[] testValues = { 0, 25, -40, -300};

            foreach (double val in testValues)
            {
                Temperature temp = new Temperature(val);

                Console.WriteLine($"Celsius: {temp.Celsius} °C");
                Console.WriteLine($" -> Fahrenheit: {temp.ToFahrenheit()} °F");
                Console.WriteLine($" -> Kelvin: {temp.ToKelvin()} K");
                Console.WriteLine(new string('-', 35));
            }

        }
    }
}