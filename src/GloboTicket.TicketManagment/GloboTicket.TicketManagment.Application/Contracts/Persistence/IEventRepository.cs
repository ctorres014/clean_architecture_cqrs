using GloboTicket.TicketManagment.Domain.Entities;

namespace GloboTicket.TicketManagment.Application.Contracts.Persistence
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
        Task<bool> IsEventEnameAndDateUnique(string name, DateTime date);
    }
}
