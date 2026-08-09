using MiniBankApp.Interfaces;

namespace MiniBankApp.Infrastructure;

public class SimpleInterestCalculator : IInterestCalculator
{
    private decimal _annualRate;

    public SimpleInterestCalculator(decimal annualRate = 0.12m)
    {
        _annualRate = annualRate;
    }

    public decimal CalculateMonthly(decimal balance)
    {
        // Basit faiz: (Bakiye * Yıllık Oran) / 12
        return balance * (_annualRate / 12m);
    }
}