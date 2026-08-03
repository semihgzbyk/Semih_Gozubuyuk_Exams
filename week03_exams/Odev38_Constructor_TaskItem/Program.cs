using System;
using Odev38_Constructor_TaskItem.Models;

namespace Odev38_Constructor_TaskItem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Üç parametreli constructor (Öncelik varsayılan "Normal" olacak)
            TaskItem task1 = new TaskItem("Veritabanı Yedeklemesi", "Ahmet Yılmaz", new DateTime(2026, 8, 10));

            // 2. Dört parametreli constructor (Öncelik "High" olarak veriliyor)
            TaskItem task2 = new TaskItem("API Güvenlik Açığı Kapatma", "Mehmet Kaya", new DateTime(2026, 8, 5), "High");

            // 3. Dört parametreli constructor (Öncelik "High" olarak veriliyor)
            TaskItem task3 = new TaskItem("Kullanıcı Giriş Hatası Düzeltme", "Ayşe Şahin", new DateTime(2026, 8, 6), "High");

            TaskItem[] tasks = { task1, task2, task3 };

            Console.WriteLine("=== TÜM GÖREV LİSTESİ ===\n");

            foreach (TaskItem task in tasks)
            {
                Console.WriteLine($"Görev Başlığı : {task.Title}");
                Console.WriteLine($"Atanan Kişi   : {task.AssignedTo}");
                Console.WriteLine($"Son Tarih     : {task.DueDate.ToShortDateString()}");
                Console.WriteLine($"Öncelik       : {task.Priority}");
                Console.WriteLine($"Tamamlandı mı : {task.IsCompleted}");
                Console.WriteLine(new string('-', 40));
            }

            // Önceliği "High" olan görevleri filtreleyip listeleme
            Console.WriteLine("\n=== YÜKSEK ÖNCELİKLİ (HIGH) GÖREVLER ===\n");

            foreach (TaskItem task in tasks)
            {
                if (task.Priority == "High")
                {
                    Console.WriteLine($"[YÜKSEK ÖNCELİK] {task.Title} -> Atanan: {task.AssignedTo} (Son Tarih: {task.DueDate.ToShortDateString()})");
                }
            }
        }
    }
}