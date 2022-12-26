using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagment.Application.Contracts
{
    public interface IEventRepository<T> where T : class
    {
        Task<Guid> AddAsync(T entity);
    }
}
