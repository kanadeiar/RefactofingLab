namespace RefactoringLab.Chapter2;

public class BaggageCalculator
{
    private const decimal CARRY_ON_FEE = 30M;
    private const decimal FIRST_BAG_FEE = 40M;
    private const decimal EXTRA_BAG_FEE = 50M;

    public decimal HolidayFeePercent { get; set; } = 0.1M;

    public decimal CalculatePrice(int bags, int carryOn, int passengers, bool isHoliday)
    {
        var total = 0M;

        if (carryOn > 0)
        {
            var fee = carryOn * CARRY_ON_FEE;
            Console.WriteLine($"Carry-on: {fee}");
            total += fee;
        }

        if (bags > 0)
        {
            var bagFee = ApplyCheckBackFee(bags, passengers);
            Console.WriteLine($"Checked: {bagFee}");
            total += bagFee;
        }

        if (isHoliday)
        {
            decimal holidayFee = total * HolidayFeePercent;
            Console.WriteLine("Holiday Fee: " + holidayFee);
            total += holidayFee;
        }

        return total;
    }

    private decimal ApplyCheckBackFee(int bags, int passengers)
    {
        if (bags <= passengers)
        {
            return bags * FIRST_BAG_FEE;
        }
        else
        {
            var firstBagFee = passengers * FIRST_BAG_FEE;
            var extraBagFee = (bags - passengers) * EXTRA_BAG_FEE;
            return firstBagFee + extraBagFee;
        }
    }
}