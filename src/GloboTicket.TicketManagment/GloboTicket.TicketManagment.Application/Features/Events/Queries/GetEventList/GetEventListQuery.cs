using GloboTicket.TicketManagment.Application.Dtos;
using MediatR;

namespace GloboTicket.TicketManagment.Application.Features.Events.Queries.GetEventList
{
    public class GetEventListQuery : IRequest<List<EventDto>>
    {

    }
}
