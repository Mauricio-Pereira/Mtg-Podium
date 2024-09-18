using Microsoft.EntityFrameworkCore;
using MtgPodium.Infrastructure;
using MtgPodium.Models.Entities;

namespace MtgPodium.Repositories;

public class RankingRepository : Repository<Ranking>, IRankingRepository
{
    public RankingRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Ranking>> GetRankingsByEventAsync(int eventId)
    {
        return await _context.Rankings
            .Include(r => r.Player)
            .Include(r => r.Event)
            .Where(r => r.Event.Id == eventId)
            .OrderBy(r => r.Position)
            .ToListAsync();
    }

    public async Task<IEnumerable<Ranking>> GetRankingsByPlayerAsync(int playerId)
    {
        return await _context.Rankings
            .Include(r => r.Player)
            .Include(r => r.Event)
            .Where(r => r.Player.Id == playerId)
            .OrderBy(r => r.Event.Date.Date)
            .ToListAsync();
    }
}