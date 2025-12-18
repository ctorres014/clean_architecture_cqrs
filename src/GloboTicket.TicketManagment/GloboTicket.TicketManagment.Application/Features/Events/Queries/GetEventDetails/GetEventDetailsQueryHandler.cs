using AutoMapper;
using GloboTicket.TicketManagment.Application.Contracts.Persistence;
using GloboTicket.TicketManagment.Application.Dtos;
using GloboTicket.TicketManagment.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagment.Application.Features.Events.Queries.GetEventDetails
{
    public class GetEventDetailsQueryHandler : IRequestHandler<GetEventDetailsQuery, EventDetailsDto>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public GetEventDetailsQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository, IAsyncRepository<Category> categoryRepository) =>
            (_eventRepository, _categoryRepository, _mapper) = (eventRepository, categoryRepository, mapper);

        public async Task<EventDetailsDto> Handle(GetEventDetailsQuery request, CancellationToken cancellationToken)
        {
            var @event = await _eventRepository.GetByIdAsync(request.Id);
            var eventDetailsDto = _mapper.Map<EventDetailsDto>(@event);

            var category = await _categoryRepository.GetByIdAsync(@event.CategoryId);
            eventDetailsDto.Category = _mapper.Map<CategoryDto>(category);

            return eventDetailsDto;
        }
    }
}
