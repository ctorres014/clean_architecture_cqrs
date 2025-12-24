using AutoMapper;
using GloboTicket.TicketManagment.Application.Dtos;
using GloboTicket.TicketManagment.Application.Features.Events.Commands.CreateEvent;
using GloboTicket.TicketManagment.Application.Features.Events.Commands.DeleteEvent;
using GloboTicket.TicketManagment.Application.Features.Events.Commands.UpdateEvent;
using GloboTicket.TicketManagment.Domain.Entities;

namespace GloboTicket.TicketManagment.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() { 
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Event, EventDetailsDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryEventDto>().ReverseMap();

            CreateMap<Event, CategoryEventDto>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
        }
    }
}
