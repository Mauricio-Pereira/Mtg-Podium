using Microsoft.EntityFrameworkCore;

namespace MtgPodium.Models.Entities.ValueObjects;

[Owned]
public class Price
{
    public decimal Amount { get; private set; }
 
    private Price() {} // Constructor para EF
 
    public Price(decimal amount)
    {
        if (amount < 0)
            throw new ArgumentException("Price cannot be negative.");
        Amount = amount;
    }
}