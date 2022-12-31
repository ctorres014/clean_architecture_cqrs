using GloboTicket.TicketManagment.Application.Contracts;
using GloboTicket.TicketManagment.Domain.Entities;
using GloboTicket.TicketManagment.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagment.EF.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(GloboTicketDbContext context): base(context) { }

        public Task<Guid> AddAsync(Event entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsEventNameAndDateUnique(string name, DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
