using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagment.Domain.Entities;
using GloboTicket.TicketManagment.EF.Context;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.TicketManagment.EF.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(GloboTicketDbContext context): base(context) { }

        public async Task<List<Category>> GetCategoriesWithEvents(bool includePassedEvents)
        {
            var categories = await _context.Categories.Include(x => x.Events).ToListAsync();
            if(!includePassedEvents)
            {
                categories.ForEach(p => p.Events.ToList().RemoveAll(c => c.Date < DateTime.Today));
            }
            return categories;
            
        }
    }
}
