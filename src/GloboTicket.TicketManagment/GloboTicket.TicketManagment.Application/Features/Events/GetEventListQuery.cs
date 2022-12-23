﻿using GloboTicket.TicketManagment.Application.Dtos;
using MediatR;

namespace GloboTicket.TicketManagment.Application.Features.Events
{
    public class GetEventListQuery : IRequest<List<EventDto>>
    {

    }
}
