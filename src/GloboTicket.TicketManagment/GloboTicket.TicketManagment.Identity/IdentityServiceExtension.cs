using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using GloboTicket.TicketManagment.Identity.Context;
using Microsoft.EntityFrameworkCore;
using GloboTicket.TicketManagment.Identity.Models;

namespace GloboTicket.TicketManagment.Identity
{
    public static class IdentityServiceExtension
    {
        public static void AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Implementation cookie for example Blazor SPA
            // The WebApp send cookie to Identity API and Identity API validate the cookie
            // If valid Identity API process the request
            services.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();
            // Add default authorization policy
            services.AddAuthorizationBuilder();

            services.AddDbContext<GloboTicketIdentityDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("GloboTicketIdentityConnectionString"));
            });
            // Add identity to user application
            // Get endpoints for identity API
            services.AddIdentityCore<ApplicationUser>()
                .AddEntityFrameworkStores<GloboTicketIdentityDbContext>()
                .AddApiEndpoints();
        }
    }
}
