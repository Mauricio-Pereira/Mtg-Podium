using MtgPodium.Repositories;

namespace MtgPodium.Infrastructure;

public interface IUnitOfWork : IDisposable
{
    IFormatRepository Formats { get; }
    IEventRepository Events { get; }
    IPlayerRepository Players { get; }
    IPlayerDeckRepository PlayerDecks { get; }
    ICardRepository Cards { get; }
    IRankingRepository Rankings { get; }

    Task<int> CompleteAsync();
}