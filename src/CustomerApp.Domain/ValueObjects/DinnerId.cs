using CustomerApp.Domain.Common;

namespace CustomerApp.Domain.ValueObjects;

public class DinnerId : ValueObject
{
    public Guid Value { get; }

    private DinnerId(Guid value)
    {
        Value = value;
    }
    
    // factory method
    public static DinnerId CreateUnique()
    {
        return new DinnerId(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}