using Microsoft.EntityFrameworkCore;
using MtgPodium.Infrastructure;
using MtgPodium.Models.Entities;

namespace MtgPodium.Repositories;

public class EventRepository : Repository<Event>, IEventRepository
{
    public EventRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Event> GetEventWithDetailsAsync(int id)
    {
        return await _context.Events
            .Include(e => e.Format)
            .Include(e => e.Rankings)
            .ThenInclude(r => r.Player)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<IEnumerable<Event>> GetAllEventsWithFormatsAsync()
    {
        return await _context.Events
            .Include(e => e.Format)
            .ToListAsync();
    }
}