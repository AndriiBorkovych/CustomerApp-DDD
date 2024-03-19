using CustomerApp.Domain.Common;

namespace CustomerApp.Domain.ValueObjects;

public class MenuId : ValueObject
{
    public Guid Value { get; }

    private MenuId(Guid value)
    {
        Value = value;
    }
    
    // factory method
    public static MenuId CreateUnique()
    {
        return new MenuId(Guid.NewGuid());
    }

    public static MenuId Create(Guid value)
    {
        return new MenuId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}