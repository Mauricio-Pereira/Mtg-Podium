using MtgPodium.Models.Entities;

namespace MtgPodium.Repositories;

public interface IPlayerDeckRepository : IRepository<PlayerDeck>
{
    // Adicione métodos específicos para PlayerDeck aqui, se necessário
    Task<PlayerDeck> GetDeckWithDetailsAsync(int id);
    Task<IEnumerable<PlayerDeck>> GetDecksByArchetypeAsync(string archetype);
}