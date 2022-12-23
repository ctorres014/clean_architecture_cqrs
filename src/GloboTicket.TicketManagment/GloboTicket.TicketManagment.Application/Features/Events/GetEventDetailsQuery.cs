using GloboTicket.TicketManagment.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagment.Application.Features.Events
{
    public class GetEventDetailsQuery : IRequest<EventDetailsDto>
    {
        public Guid Id { get; set; }
    }
}
