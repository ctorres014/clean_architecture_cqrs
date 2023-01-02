using GloboTicket.TicketManagement.Application.Contracts.Persistence;
using GloboTicket.TicketManagment.Application.Contracts;
using GloboTicket.TicketManagment.EF.Context;
using GloboTicket.TicketManagment.EF.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalTicket.TicketManagment.DependencyInjection
{
    public static class ServicesExtensions
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GloboTicketDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("GloboTicketTicketManagerConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeOf(BaseRepository<>));

            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
