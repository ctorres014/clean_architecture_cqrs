using GloboTicket.TicketManagment.WebApi;

var builder = WebApplication.CreateBuilder(args);

var app = builder
            .ConfigureServices()
            .ConfigurePipeLine();

await app.ResetDatabaseAsync();

app.Run();
