using RefactoringLab.Func;

ConsoleHelper.PrintHeader("Опытно-экспериментальное приложение", "Опыты над рефакторингом");

var email = Email.Create("nik@mail.ru") switch
{
    { Success : false } => throw new ArgumentException("test"),
    { } some => some.Value,
};

var name = CustomerName.Create("Andrei") switch
{
    { Success : false } => throw new ArgumentException("test"),
    { } some => some.Value,
};

var customer = new Customer(email, name);
customer.ChangeEmail(email);
customer.ChangeName(name);

Console.WriteLine($"Имя: {(string)customer.Name} почта: {(string)customer.Email}");
Console.WriteLine(customer.Name);
Console.WriteLine(customer.Email);


ConsoleHelper.PrintFooter();