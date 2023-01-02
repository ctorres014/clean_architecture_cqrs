using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagment.Domain.Entities;
using GloboTicket.TicketManagment.EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagment.EF.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(GloboTicketDbContext context): base(context) { }

        public async Task<List<Order>> GetPagedOrdersForMonth(DateTime date, int page, int size)
        {
            return await _context.Orders.Where(e => e.OrderPlaced.Month == date.Month && e.OrderPlaced.Year == date.Year)
                .Skip((page -1) * size).Take(size).AsNoTracking().ToListAsync();
        }

        public async Task<int> GetTotalCountOfOrdersForMonth(DateTime date)
        {
            return await _context.Orders.CountAsync(e => e.OrderPlaced.Month == date.Month && e.OrderPlaced.Year == date.Year);
        }
    }
}
