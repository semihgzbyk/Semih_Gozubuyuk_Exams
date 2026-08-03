using System;

namespace Odev06_WaterMeter.Models
{
    public class WaterMeter
    {
        // Private field'lar
        private string meterNumber = "";
        private int currentReading;

        // Property'ler
        public string MeterNumber
        {
            get
            {
                return meterNumber;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hata: Sayaç numarası boş olamaz!");
                }
                meterNumber = value;
            }
        }

        public int CurrentReading
        {
            get
            {
                return currentReading;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hata: Sayaç okuması negatif olamaz!");
                }
                currentReading = value;
            }
        }

        // Yapıcı Metot (Constructor)
        public WaterMeter(string meterNumber, int initialReading)
        {
            MeterNumber = meterNumber;
            CurrentReading = initialReading;
        }

        // Metot 1: Sayaç Okuması Güncelleme
        public void RecordReading(int newReading)
        {
            if (newReading < CurrentReading)
            {
                throw new InvalidOperationException($"Hata: Yeni okuma ({newReading}), mevcut okumadan ({CurrentReading}) küçük olamaz! Sayaç geriye doğru sayamaz.");
            }

            CurrentReading = newReading;
            Console.WriteLine($"[GÜNCELLENDİ] Sayaç okuması {CurrentReading} olarak kaydedildi.");
        }

        // Metot 2: Tüketim Hesaplama
        public int CalculateConsumption(int previousReading)
        {
            if (previousReading < 0)
            {
                throw new ArgumentException("Hata: Geçen ayki okuma negatif olamaz!");
            }

            if (previousReading > CurrentReading)
            {
                throw new InvalidOperationException("Hata: Geçen ayki okuma, mevcut sayac değerinden büyük olamaz!");
            }

            int consumption = CurrentReading - previousReading;
            return consumption;
        }
    }
}