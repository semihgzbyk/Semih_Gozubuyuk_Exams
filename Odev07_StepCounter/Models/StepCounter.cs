using System;

namespace Odev07_StepCounter.Models
{
    public class StepCounter
    {
        // Private field'lar
        private int dailyGoal;
        private int steps;

        // Property'ler
        public int DailyGoal
        {
            get
            {
                return dailyGoal;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Hata: Günlük hedef 0'dan büyük olmalıdır!");
                }
                dailyGoal = value;
            }
        }

        public int Steps
        {
            get
            {
                return steps;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Hata: Adım sayısı negatif olamaz!");
                }
                steps = value;
            }
        }

        // Yapıcı Metot
        public StepCounter(int dailyGoal)
        {
            DailyGoal = dailyGoal;
        }

        // Metot 1: Adım ekleme
        public void AddSteps(int count)
        {
            if (count <= 0)
            {
                throw new ArgumentException("Hata: Eklenen adım sayısı 0'dan büyük olmalıdır!");
            }

            Steps += count;
        }

        // Metot 2: Hedefe ulaşıldı mı kontrolü
        public bool IsGoalReached()
        {
            return Steps >= DailyGoal;
        }
    }
}