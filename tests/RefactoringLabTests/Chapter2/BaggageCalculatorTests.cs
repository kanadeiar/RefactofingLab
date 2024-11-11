using FluentAssertions;
using FrameworkConsoleApp1Tests.Infrastructure;
using RefactoringLab.Chapter2;

namespace RefactoringLabTests.Chapter2;

public class BaggageCalculatorTests
{
    [Theory]
    [InlineAutoMoqData(0, 0, 0, 1, 2023, 3, 1)]
    public void TestPriceWithNoBagsIsCorrect(decimal expected, int numChecked, int numCarryOn, int numPassengers, 
        int year, int month, int day)
    {
        var calculator = new BaggageCalculator();
        DateTime travelDate = new(year, month, day);

        var actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelDate.Month >= 11 || travelDate.Month <= 2);

        actualPrice.Should().Be(expected);
    }

    [Theory]
    [InlineAutoMoqData(190, 3, 2, 2, 2023, 3, 1)]
    public void TestPriceWithTwoPassengersAndThreeCheckedIsCorrect(decimal expected, int numChecked, int numCarryOn, int numPassengers, 
        int year, int month, int day)
    {
        var calculator = new BaggageCalculator();
        DateTime travelDate = new(year, month, day);

        var actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelDate.Month >= 11 || travelDate.Month <= 2);

        actualPrice.Should().Be(expected);
    }

    [Theory]
    [InlineAutoMoqData(30, 0, 1, 1, 2023, 3, 1)]
    public void PriceWithCarryOnBagIsCorrect(decimal expected, int numChecked, int numCarryOn, int numPassengers,
        int year, int month, int day)
    {
        var calculator = new BaggageCalculator();
        DateTime travelDate = new(year, month, day);
        
        var actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelDate.Month >= 11 || travelDate.Month <= 2);

        actualPrice.Should().Be(expected);
    }

    [Theory]
    [InlineAutoMoqData(120, 2, 1, 1, 2023, 3, 1)]
    public void PriceWithTwoCheckedIsCorrect(decimal expected, int numChecked, int numCarryOn, int numPassengers,
        int year, int month, int day)
    {
        var calculator = new BaggageCalculator();
        DateTime travelDate = new(year, month, day);

        var actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelDate.Month >= 11 || travelDate.Month <= 2);

        actualPrice.Should().Be(expected);
    }

    [Theory]
    [InlineAutoMoqData(209, 3, 2, 2, 2023, 12, 19)]
    public void HolidayPriceIsCorrect(decimal expected, int numChecked, int numCarryOn, int numPassengers,
        int year, int month, int day)
    {
        var calculator = new BaggageCalculator();
        DateTime travelDate = new(year, month, day);

        var actualPrice = calculator.CalculatePrice(numChecked, numCarryOn, numPassengers, travelDate.Month >= 11 || travelDate.Month <= 2);

        actualPrice.Should().Be(expected);
    }
}