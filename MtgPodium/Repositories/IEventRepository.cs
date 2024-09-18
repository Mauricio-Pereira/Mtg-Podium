using MtgPodium.Models.Entities;

namespace MtgPodium.Repositories;

public interface IEventRepository : IRepository<Event>
{
    // Adicione métodos específicos para Event aqui, se necessário
    Task<Event> GetEventWithDetailsAsync(int id);
    Task<IEnumerable<Event>> GetAllEventsWithFormatsAsync();
}