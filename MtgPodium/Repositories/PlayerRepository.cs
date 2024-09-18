using Microsoft.EntityFrameworkCore;
using MtgPodium.Infrastructure;
using MtgPodium.Models.Entities;

namespace MtgPodium.Repositories;

public class PlayerRepository : Repository<Player>, IPlayerRepository
{
    public PlayerRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Player> GetPlayerWithDecksAsync(int id)
    {
        return await _context.Players
            .Include(p => p.PlayerDecks)
            .ThenInclude(pd => pd.Cards)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Player>> GetAllPlayersWithDecksAsync()
    {
        return await _context.Players
            .Include(p => p.PlayerDecks)
            .ToListAsync();
    }
}