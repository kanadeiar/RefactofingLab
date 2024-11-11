namespace RefactoringLab.Common;

public abstract record Code
{
    public Some<int> OptionCreate(Code code)
    {
        return code switch
        {
            FirstCode => Option.Some(1),
            SecondCode => Option.Some(2),
            _ => Option.None<int>("none"),
        };
    }

    public string Create(Code code)
    {
        return code switch
        {
            FirstCode => "first",
            SecondCode { id:1 } => "number one",
            SecondCode (var id) => "second " + id,
            _ => "none",
        };
    }

    public static Code First => new FirstCode();
    public static Code Second(int id) => new SecondCode(id);

    private record FirstCode : Code;
    private record SecondCode(int id) : Code;
}