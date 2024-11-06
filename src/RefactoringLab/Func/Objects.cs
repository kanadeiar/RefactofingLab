namespace RefactoringLab.Func;

public class Email
{
    private string _value = string.Empty;

    public static Some<Email> Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email) || email.Length > 100)
            return Option.None<Email>("Неверное значение параметра " + nameof(email));

        return Option.Some(new Email { _value = email });
    }

    private Email() { }

    public static implicit operator string(Email email)
    {
        return email._value;
    }
}

public class CustomerName
{
    private string _value = string.Empty;

    public static Some<CustomerName> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name) || name.Length > 50)
            return Option.None<CustomerName>("Неверное значение параметра " + nameof(name));

        return Option.Some(new CustomerName { _value = name });
    }

    private CustomerName() { }

    public static implicit operator string(CustomerName name)
    {
        return name._value;
    }
}

public class Customer(Email email, CustomerName name)
{
    public Email Email { get; private set; } = email;

    public CustomerName Name { get; private set; } = name;

    public void ChangeEmail(Email email)
    {
        ArgumentNullException.ThrowIfNull(email);

        Email = email;
    }

    public void ChangeName(CustomerName name)
    {
        ArgumentNullException.ThrowIfNull(name);

        Name = name;
    }
}