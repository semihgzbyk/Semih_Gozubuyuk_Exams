namespace MiniBankApp.Interfaces;

public interface IInterestCalculator
{
    decimal CalculateMonthly(decimal balance);
}