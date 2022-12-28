﻿using GloboTicket.TicketManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagment.Application.Contracts
{
    public interface IEventRepository : IAsyncRepository<Event>
    {
        Task<Guid> AddAsync(Event entity);
        Task<bool> IsEventNameAndDateUnique(string name, DateTime date);
    }
}
