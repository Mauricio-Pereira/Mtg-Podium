using Microsoft.EntityFrameworkCore;

namespace MtgPodium.Models.Entities.ValueObjects;

[Owned]
public class Location
{
    public string City { get; private set; }
    public string State { get; private set; }
    public string Country { get; private set; }
 
    private Location() {} // Constructor para EF
 
    public Location(string city, string state, string country)
    {
        City = city;
        State = state;
        Country = country;
    }
}