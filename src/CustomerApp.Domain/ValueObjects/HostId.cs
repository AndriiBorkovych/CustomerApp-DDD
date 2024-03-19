using CustomerApp.Domain.Common;

namespace CustomerApp.Domain.ValueObjects;

public class HostId : ValueObject
{
    private HostId(Guid value)
    {
        Value = value;
    }

    private HostId(string value)
    {
        Value = Guid.Parse(value);
    }
    
    public Guid Value { get; }
    
    // factory method
    public static HostId CreateUnique()
    {
        return new HostId(Guid.NewGuid());
    }

    public static HostId Create(string value)
    {
        return new HostId(value);
    }
    
    public static HostId Create(Guid value)
    {
        return new HostId(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}