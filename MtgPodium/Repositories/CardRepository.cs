using Microsoft.EntityFrameworkCore;
using MtgPodium.Infrastructure;
using MtgPodium.Models;
using MtgPodium.Models.Entities;

namespace MtgPodium.Repositories;

public class CardRepository : Repository<Card>, ICardRepository
{
    public CardRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Card> GetCardByNameAsync(string name)
    {
        return await _context.Cards
            .FirstOrDefaultAsync(c => c.Name == name);
    }

    public async Task<IEnumerable<Card>> GetCardsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
    {
        return await _context.Cards
            .Where(c => c.Price.Amount >= minPrice && c.Price.Amount <= maxPrice)
            .ToListAsync();
    }
}