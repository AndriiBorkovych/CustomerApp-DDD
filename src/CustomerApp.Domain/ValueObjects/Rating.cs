using CustomerApp.Domain.Common;

namespace CustomerApp.Domain.ValueObjects;

public class Rating : ValueObject
{
    private Rating(double value)
    {
        Value = value;
    }
    
    public double Value { get; private set; }

    public static Rating Create(double value)
    {
        return new Rating(value);
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}