using AutoMapper;
using GloboTicket.TicketManagment.Application.Dtos;
using GloboTicket.TicketManagment.Application.Features.Events.Commands.CreateEvent;
using GloboTicket.TicketManagment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagment.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() { 
            CreateMap<Event, EventDto>().ReverseMap();
            CreateMap<Event, EventDetailsDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryEventList>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
        }
    }
}
