using GlobalTicket.TicketManagment.Persistence;
using GlobalTicket.TicketManagment.Persistence.Context;
using GloboTicket.TicketManagment.Application;
using GloboTicket.TicketManagment.Identity;
using GloboTicket.TicketManagment.Identity.Models;
using GloboTicket.TicketManagment.WebApi.Middleware;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace GloboTicket.TicketManagment.WebApi
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddServiceApplication();
            builder.Services.AddServicePersistence(builder.Configuration);
            builder.Services.AddIdentityServices(builder.Configuration);
            builder.Services.AddControllers();
            // we could apply configuration cors for front end application
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            return builder.Build();
        }

        public static WebApplication ConfigurePipeLine(this WebApplication app)
        {
            app.UseCors();
            app.MapIdentityApi<ApplicationUser>();
            // Apply Logout wiith minimal API
            app.MapGet("/logout", async (ClaimsPrincipal user,
                SignInManager<ApplicationUser> signInmanager) =>
            {
                await signInmanager.SignOutAsync();
                return TypedResults.Ok();
            });

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCustomExceptionHandler();
            app.UseHttpsRedirection();
            app.MapControllers();

            return app;
        }

        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<GloboTicketDbContext>();
                if (context is not null)
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
