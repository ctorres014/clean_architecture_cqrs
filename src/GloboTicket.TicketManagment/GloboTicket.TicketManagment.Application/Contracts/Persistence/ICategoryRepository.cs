using GloboTicket.TicketManagment.Domain.Entities;

namespace GloboTicket.TicketManagment.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents);
    }
}
