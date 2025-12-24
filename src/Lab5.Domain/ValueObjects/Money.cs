namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;

public record Money
{
    public Money(decimal value)
    {
        if (value < 0)
        {
            throw new ArgumentException("Money cannot be negative", nameof(value));
        }

        Value = value;
    }

    public decimal Value { get; }

    public static Money operator -(Money left, Money right)
    {
        decimal value = left.Value - right.Value;

        return new Money(value);
    }

    public static Money operator +(Money left, Money right)
    {
        decimal value = left.Value + right.Value;
        return new Money(value);
    }

    public static bool operator <(Money left, Money right)
        => left.Value < right.Value;

    public static bool operator >(Money left, Money right)
        => left.Value > right.Value;
}