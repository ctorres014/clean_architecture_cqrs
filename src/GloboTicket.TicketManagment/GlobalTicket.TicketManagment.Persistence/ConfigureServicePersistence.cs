using GlobalTicket.TicketManagment.Persistence.Context;
using GlobalTicket.TicketManagment.Persistence.Repositories;
using GloboTicket.TicketManagment.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalTicket.TicketManagment.Persistence
{
    public static class ConfigureServicePersistence
    {
        public static IServiceCollection AddServicePersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<GloboTicketDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("GloboTicketManagmentConnectionString"))
            );

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
