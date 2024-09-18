using MtgPodium.Models.Entities;

namespace MtgPodium.Repositories;

public interface IRankingRepository : IRepository<Ranking>
{
    // Adicione métodos específicos para Ranking aqui, se necessário
    Task<IEnumerable<Ranking>> GetRankingsByEventAsync(int eventId);
    Task<IEnumerable<Ranking>> GetRankingsByPlayerAsync(int playerId);
}