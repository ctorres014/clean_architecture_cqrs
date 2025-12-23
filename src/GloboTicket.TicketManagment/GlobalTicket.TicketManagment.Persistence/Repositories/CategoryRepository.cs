using GlobalTicket.TicketManagment.Persistence.Context;
using GloboTicket.TicketManagment.Application.Contracts.Persistence;
using GloboTicket.TicketManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GlobalTicket.TicketManagment.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(GloboTicketDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents)
        {
            if (includePassedEvents) { 
                return await _dbContext.Categories
                    .Include(c => c.Events.Where(e => e.Date <= DateTime.Now))
                    .ToListAsync();
            }

            return await _dbContext.Categories
                    .Include(c => c.Events.Where(e => e.Date >= DateTime.Now))
                    .ToListAsync();

        } 
        
        
    }
}
