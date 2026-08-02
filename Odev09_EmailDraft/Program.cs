using System;
using Odev09_EmailDraft.Models;

namespace Odev09_EmailDraft
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Eksik bilgiyle (alıcı ve konu boş) taslak oluşturup Send() deneyin
            EmailDraft draft = new EmailDraft("", "", "Merhaba, bu bir test mesajıdır.");
            Console.WriteLine("--- Eksik Bilgi İle Gönderim Denemesi ---");
            draft.Send();

            // 2. Bilgileri tamamlayıp gönderin
            Console.WriteLine("\n--- Bilgiler Tamamlanıyor ---");
            draft.To = "ahmet@example.com";
            draft.Subject = "Proje Güncellemesi";
            draft.Send();

            // 3. Gönderildikten sonra UpdateBody deneyin
            Console.WriteLine("\n--- Gönderim Sonrası Güncelleme Denemesi ---");
            try
            {
                draft.UpdateBody("Yeni mesaj metni");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ENGELENDİ] {ex.Message}");
            }

            Console.WriteLine($"\nMevcut Mesaj Metni: {draft.Body}");
        }
    }
}