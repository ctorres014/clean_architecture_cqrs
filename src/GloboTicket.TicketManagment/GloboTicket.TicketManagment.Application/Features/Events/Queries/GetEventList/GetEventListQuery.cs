using AutoMapper;
using GloboTicket.TicketManagment.Application.Contracts.Persistence;
using GloboTicket.TicketManagment.Application.Dtos;
using GloboTicket.TicketManagment.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagment.Application.Features.Events.Queries.GetEventList
{
    public class GetEventListQuery : IRequest<List<EventDto>>
    {

    }
}
