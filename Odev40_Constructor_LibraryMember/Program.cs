using System;
using Odev40_Constructor_LibraryMember.Models;

namespace Odev40_Constructor_LibraryMember
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Üç parametreli constructor (Üyelik tipi varsayılan "Standard" olacak)
            LibraryMember member1 = new LibraryMember(101, "Ali Kemal", new DateTime(2025, 3, 15));
            member1.BorrowedBookCount = 2;

            // 2. Dört parametreli constructor (Üyelik tipi "Premium" olarak belirtiliyor)
            LibraryMember member2 = new LibraryMember(102, "Ayşe Arslan", new DateTime(2026, 1, 10), "Premium");
            member2.BorrowedBookCount = 5;

            LibraryMember[] members = { member1, member2 };

            Console.WriteLine("=== KÜTÜPHANE ÜYE LİSTESİ ===\n");

            // Üye detaylarını, üyelik tipini ve kayıt tarihini yazdırma
            foreach (LibraryMember member in members)
            {
                Console.WriteLine($"Üye No       : {member.MemberId}");
                Console.WriteLine($"Ad Soyad     : {member.FullName}");
                Console.WriteLine($"Üyelik Tipi  : {member.MembershipType}");
                Console.WriteLine($"Kayıt Tarihi : {member.RegistrationDate.ToShortDateString()}");
                Console.WriteLine($"Ödünç Kitap  : {member.BorrowedBookCount}");
                Console.WriteLine(new string('-', 40));
            }
        }
    }
}