using GloboTicket.TicketManagment.Application.Dtos;
using MediatR;

namespace GloboTicket.TicketManagment.Application.Features.Events.Queries.GetEventDetails
{
    public class GetEventDetailsQuery : IRequest<EventDetailsDto>
    {
        public Guid Id { get; set; }
    }
}
