using RefactoringLab.Func;

ConsoleHelper.PrintHeader("Опытно-экспериментальное приложение", "Опыты над рефакторингом");

var email = Email.Create("nik@mail.ru")
    .TryGetValue(_ => throw new ArgumentException("test"));

var name = CustomerName.Create("Andrei")
    .TryGetValue(_ => CustomerName.Create("Tom")
        .TryGetValue(_ => throw new ArgumentException()));

var customer = new Customer(email, name);
customer.ChangeEmail(email);
customer.ChangeName(name);

Console.WriteLine($"Имя: {(string)customer.Name} почта: {(string)customer.Email}");
Console.WriteLine(customer.Name);
Console.WriteLine(customer.Email);


ConsoleHelper.PrintFooter();