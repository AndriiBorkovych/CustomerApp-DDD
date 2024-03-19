using CustomerApp.Domain.Common;

namespace CustomerApp.Domain.ValueObjects;

public class MenuItemId : ValueObject
{
    public Guid Value { get; private set; }

    private MenuItemId(Guid value)
    {
        Value = value;
    }
    
    // factory method
    public static MenuItemId CreateUnique()
    {
        return new MenuItemId(Guid.NewGuid());
    }
    
    public static MenuItemId Create(Guid value)
    {
        return new MenuItemId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}