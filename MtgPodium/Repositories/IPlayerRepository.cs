using MtgPodium.Models.Entities;

namespace MtgPodium.Repositories;

public interface IPlayerRepository : IRepository<Player>
{
    Task<Player> GetPlayerWithDecksAsync(int id);
}