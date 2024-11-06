namespace RefactoringLab.Func;

public class Product(string name, int amount, decimal price)
{
    public string Name { get; } = name
        .RequireNot(string.IsNullOrEmpty(name));

    public int Amount { get; } = amount
        .Require(amount >= 0);

    public decimal Price { get; } = price
        .Require(price > 0);
}