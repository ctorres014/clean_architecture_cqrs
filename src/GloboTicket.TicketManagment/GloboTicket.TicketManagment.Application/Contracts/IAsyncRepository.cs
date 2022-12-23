using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagment.Application.Contracts
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetById(Guid id);
        Task AddAync(T entity);
        Task UpdateAync(T entity);
        Task DeleteAync(Guid id);
    }
}
