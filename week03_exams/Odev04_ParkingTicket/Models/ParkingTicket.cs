using System;

namespace Odev04_ParkingTicket.Models
{
    public class ParkingTicket
    {
        // Private field'lar
        private string plateNumber;
        private DateTime entryTime;
        private bool isPaid;
        private decimal calculatedFee; // Ödenmesi gereken toplam ücreti tutar

        // Property'ler 
        public string PlateNumber
        {
            get
            {
                return plateNumber;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hata: Plaka bilgisi boş olamaz!");
                }
                plateNumber = value;
            }
        }

        public DateTime EntryTime
        {
            get
            {
                return entryTime;
            }
            private set
            {
                entryTime = value;
            }
        }

        public bool IsPaid
        {
            get
            {
                return isPaid;
            }
            private set
            {
                isPaid = value;
            }
        }

        // Yapıcı Metot (Constructor)
        public ParkingTicket(string plateNumber, DateTime entryTime)
        {
            PlateNumber = plateNumber;
            EntryTime = entryTime;
            IsPaid = false;
            calculatedFee = 0;
        }

        // Metot 1: Ücret Hesaplama
        public decimal CalculateFee(int hours, decimal hourlyRate)
        {
            if (hours <= 0)
            {
                throw new ArgumentException("Hata: Kalınan saat 0 veya negatif olamaz!");
            }

            if (hourlyRate <= 0)
            {
                throw new ArgumentException("Hata: Saatlik ücret 0 veya negatif olamaz!");
            }

            calculatedFee = hours * hourlyRate;
            Console.WriteLine($"[HESAPLANDI] {PlateNumber} plakalı araç {hours} saat kaldı. Toplam Ücret: {calculatedFee} TL");
            
            return calculatedFee;
        }

        // Metot 2: Ödeme Alma
        public void Pay(decimal amount)
        {
            if (calculatedFee == 0)
            {
                Console.WriteLine("Uyarı: Henüz ücret hesaplanmadı. Lütfen önce CalculateFee metodunu çalıştırın.");
                return;
            }

            if (amount < calculatedFee)
            {
                IsPaid = false;
                Console.WriteLine($"[ÖDENEMEDİ] Verilen Tutarı: {amount} TL | Gerekli Tutar: {calculatedFee} TL. Yetersiz ödeme!");
            }
            else
            {
                IsPaid = true;
                Console.WriteLine($"[ÖDENDİ] {amount} TL ödeme alındı. Bilet kapatıldı. İyi günler!");
            }
        }
    }
}