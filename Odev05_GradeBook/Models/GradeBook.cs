using System;

namespace Odev05_GradeBook.Models
{
    public class GradeBook
    {
        // Private field'lar
        private string studentName ="";
        private int examCount;
        private int totalScore;

        // Property'ler 
        public string StudentName
        {
            get
            {
                return studentName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hata: Öğrenci adı boş olamaz!");
                }
                studentName = value;
            }
        }

        public int ExamCount
        {
            get
            {
                return examCount;
            }
            private set
            {
                examCount = value;
            }
        }

        public int TotalScore
        {
            get
            {
                return totalScore;
            }
            private set
            {
                totalScore = value;
            }
        }

        // Yapıcı Metot (Constructor)
        public GradeBook(string studentName)
        {
            StudentName = studentName;
            ExamCount = 0;
            TotalScore = 0;
        }

        // Metot 1: Sınav Notu Ekleme
        public void AddExamScore(int score)
        {
            // 0 - 100 arası kontrolü (Geçersizse hata fırlat)
            if (score < 0 || score > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(score), "Hata: Sınav notu 0 ile 100 arasında olmalıdır!");
            }

            TotalScore += score;
            ExamCount += 1;

            Console.WriteLine($"[EKLENDİ] {StudentName} için {score} notu başarıyla işlendi.");
        }

        // Metot 2: Ortalama Hesaplama
        public double GetAverage()
        {
            if (ExamCount == 0)
            {
                return 0.0;
            }

            // Tam sayı bölmesinde küsürat kaybolmasın diye double dönüşümü yapıyoruz
            return (double)TotalScore / ExamCount;
        }
    }
}