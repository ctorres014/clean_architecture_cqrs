using GloboTicket.TicketManagment.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GloboTicket.TicketManagment.Identity.Context
{
    public class GloboTicketIdentityDbContext: IdentityDbContext<ApplicationUser>
    {
    
        public GloboTicketIdentityDbContext(DbContextOptions<GloboTicketIdentityDbContext> options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
            .LogTo(Console.WriteLine)
            .EnableSensitiveDataLogging();
    }
}
