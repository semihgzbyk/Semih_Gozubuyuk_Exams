using System;
using Odev06_WaterMeter.Models;

namespace Odev06_WaterMeter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SU SAYACI TAKİP SİSTEMİ ===\n");

            // 1. Başlangıç okuması 1000 olan bir sayaç nesnesi oluşturma
            WaterMeter meter = new WaterMeter("MTR-2024-001", 1000);
            Console.WriteLine($"Sayaç No: {meter.MeterNumber} | Başlangıç Okuması: {meter.CurrentReading}\n");

            // 2. 1250 okumasını kaydetme
            Console.WriteLine("--- Yeni Okuma Giriliyor ---");
            meter.RecordReading(1250);
            Console.WriteLine($"Mevcut Okuma: {meter.CurrentReading}\n");

            // 3. Geçen ayki okumayı 1000 kabul edip tüketimi hesaplama
            Console.WriteLine("--- Tüketim Hesaplama ---");
            int gecenAyOkuma = 1000;
            int buAyTuketim = meter.CalculateConsumption(gecenAyOkuma);

            Console.WriteLine($"Geçen Ayki Okuma: {gecenAyOkuma}");
            Console.WriteLine($"Bu Ayki Okuma   : {meter.CurrentReading}");
            Console.WriteLine($"Hesaplanan Tüketim: {buAyTuketim} birim\n");

            // 4. Hata denemesi (Geriye dönük sayaç okuması girme)
            Console.WriteLine("--- Geçersiz Okuma Denemesi ---");
            try
            {
                Console.WriteLine("1100 okuması girilmeye çalışılıyor...");
                meter.RecordReading(1100);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[YAKALANAN HATA] {ex.Message}");
            }

            Console.WriteLine("\nİşlem tamamlandı.");
        }
    }
}