using MtgPodium.Models;
using MtgPodium.Models.Entities;

namespace MtgPodium.Repositories;

public interface ICardRepository : IRepository<Card>
{
    // Adicione métodos específicos para Card aqui, se necessário
    Task<Card> GetCardByNameAsync(string name);
    Task<IEnumerable<Card>> GetCardsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
}