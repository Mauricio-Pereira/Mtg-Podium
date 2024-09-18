using Microsoft.EntityFrameworkCore;
using MtgPodium.Infrastructure;
using MtgPodium.Models.Entities;

namespace MtgPodium.Repositories;

public class PlayerDeckRepository : Repository<PlayerDeck>, IPlayerDeckRepository
{
    public PlayerDeckRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<PlayerDeck> GetDeckWithDetailsAsync(int id)
    {
        return await _context.PlayerDecks
            .Include(pd => pd.Player)
            .Include(pd => pd.Event)
            .Include(pd => pd.Cards)
            .FirstOrDefaultAsync(pd => pd.Id == id);
    }

    public async Task<IEnumerable<PlayerDeck>> GetDecksByArchetypeAsync(string archetype)
    {
        return await _context.PlayerDecks
            .Where(pd => pd.Archetype == archetype)
            .Include(pd => pd.Cards)
            .ToListAsync();
    }
}