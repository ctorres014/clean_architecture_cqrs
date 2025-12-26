using GloboTicket.TicketManagment.WebApi;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();
Log.Information("GloboTicket API Starting");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext());

var app = builder
            .ConfigureServices()
            .ConfigurePipeLine();

app.UseSerilogRequestLogging();

//await app.ResetDatabaseAsync();

app.Run();
