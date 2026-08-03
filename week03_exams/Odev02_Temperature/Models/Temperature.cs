using System;

namespace Odev02_Temperature.Models
{
    public class Temperature
    {
        private double celsius;

        public double Celsius
        {
            get
            {
                return celsius;
            }
            set
            {
                if (value < -273.15)
                {
                    // Hatalı değer girildiği an program çalışmayı burada keser ve durur
                    throw new ArgumentOutOfRangeException("Hata: Sıcaklık -273.15 °C altında olamaz!");
                }
                celsius = value;
            }
        }

        public Temperature(double celsius)
        {
            Celsius = celsius;
        }

        public double ToFahrenheit()
        {
            return Math.Round((Celsius * 1.8) + 32, 2);
        }

        public double ToKelvin()
        {
            return Math.Round(Celsius + 273.15, 2);
        }
    }
}