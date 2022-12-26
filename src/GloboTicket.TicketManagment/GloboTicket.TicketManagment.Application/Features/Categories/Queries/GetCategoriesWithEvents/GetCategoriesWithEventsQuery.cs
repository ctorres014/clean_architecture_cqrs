using GloboTicket.TicketManagment.Application.Dtos;
using MediatR;

namespace GloboTicket.TicketManagment.Application.Features.Categories.Queries.GetCategoriesWithEvents
{
    public class GetCategoriesWithEventsQuery : IRequest<CategoryEventList>
    {
        public bool IncludeHistory { get; set; }
    }
}
