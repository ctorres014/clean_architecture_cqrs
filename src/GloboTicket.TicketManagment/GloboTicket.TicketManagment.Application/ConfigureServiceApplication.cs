using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GloboTicket.TicketManagment.Application
{
    public static class ConfigureServiceApplication
    {
        public static IServiceCollection AddServiceApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
