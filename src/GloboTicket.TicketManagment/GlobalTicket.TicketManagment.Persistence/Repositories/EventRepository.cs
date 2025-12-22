using GlobalTicket.TicketManagment.Persistence.Context;
using GloboTicket.TicketManagment.Application.Contracts.Persistence;
using GloboTicket.TicketManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlobalTicket.TicketManagment.Persistence.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(GloboTicketDbContext dbContext) : base(dbContext)
        {
        }

        public Task<bool> IsEventEnameAndDateUnique(string name, DateTime date)
        {
            var match = _dbContext.Events.FirstOrDefaultAsync(e => e.Name.Equals(name) && e.Date.Equals(date));
            return Task.FromResult(match == null);
        }
    }
}
