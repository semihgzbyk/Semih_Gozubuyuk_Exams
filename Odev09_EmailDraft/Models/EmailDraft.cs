using System;

namespace Odev09_EmailDraft.Models
{
    public class EmailDraft
    {
        // Private field'lar
        private string to = "";
        private string subject = "";
        private string body = "";
        private bool isSent;

        // Property'ler
        public string To
        {
            get
            {
                return to;
            }
            set
            {
                if (IsSent)
                {
                    throw new InvalidOperationException("Hata: Gönderilmiş e-postanın alıcısı değiştirilemez!");
                }
                to = value;
            }
        }

        public string Subject
        {
            get
            {
                return subject;
            }
            set
            {
                if (IsSent)
                {
                    throw new InvalidOperationException("Hata: Gönderilmiş e-postanın konusu değiştirilemez!");
                }
                subject = value;
            }
        }

        public string Body
        {
            get
            {
                return body;
            }
            private set
            {
                body = value;
            }
        }

        public bool IsSent
        {
            get
            {
                return isSent;
            }
            private set
            {
                isSent = value;
            }
        }

        // Yapıcı Metot
        public EmailDraft(string to, string subject, string body)
        {
            To = to;
            Subject = subject;
            Body = body;
        }

        // Metot 1: Metin Güncelleme
        public void UpdateBody(string newBody)
        {
            if (IsSent)
            {
                throw new InvalidOperationException("Hata: E-posta zaten gönderildiği için metin güncellenemez!");
            }

            Body = newBody;
        }

        // Metot 2: E-posta Gönderme
        public bool Send()
        {
            if (string.IsNullOrWhiteSpace(To) || string.IsNullOrWhiteSpace(Subject))
            {
                Console.WriteLine("Uyarı: Alıcı veya konu alanı boş olduğu için e-posta gönderilemedi!");
                return false;
            }

            IsSent = true;
            Console.WriteLine("E-posta başarıyla gönderildi.");
            return true;
        }
    }
}