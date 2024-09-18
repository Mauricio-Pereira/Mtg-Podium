using Microsoft.EntityFrameworkCore;

namespace MtgPodium.Models.Entities.ValueObjects;

[Owned]
public class EventDate
{
    public DateTime Date { get; private set; }
 
    private EventDate() {} // Constructor para EF
 
    public EventDate(DateTime date)
    {
        if (date > DateTime.Now)
            throw new ArgumentException("Event date cannot be in the future.");
        Date = date;
    }
}