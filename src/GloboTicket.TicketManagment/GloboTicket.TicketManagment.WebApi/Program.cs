using GloboTicket.TicketManagment.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServiceApplication();

var app = builder.Build();


app.Run();
