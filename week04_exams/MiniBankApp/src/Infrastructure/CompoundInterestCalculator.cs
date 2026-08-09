using MiniBankApp.Interfaces;

namespace MiniBankApp.Infrastructure;

public class CompoundInterestCalculator : IInterestCalculator
{
    private decimal _annualRate;

    public CompoundInterestCalculator(decimal annualRate = 0.12m)
    {
        _annualRate = annualRate;
    }

    public decimal CalculateMonthly(decimal balance)
    {
        // Aylık bileşik faiz getiri hesabı
        double monthlyRate = (double)(_annualRate / 12m);
        double result = (double)balance * Math.Pow(1 + monthlyRate, 1) - (double)balance;
        return (decimal)result;
    }
}