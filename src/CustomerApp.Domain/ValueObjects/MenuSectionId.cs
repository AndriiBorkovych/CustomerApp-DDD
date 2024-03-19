using CustomerApp.Domain.Common;

namespace CustomerApp.Domain.ValueObjects;

public class MenuSectionId : ValueObject
{
    public Guid Value { get; }

    private MenuSectionId(Guid value)
    {
        Value = value;
    }
    
    // factory method
    public static MenuSectionId CreateUnique()
    {
        return new MenuSectionId(Guid.NewGuid());
    }
    
    public static MenuSectionId Create(Guid value)
    {
        return new MenuSectionId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}