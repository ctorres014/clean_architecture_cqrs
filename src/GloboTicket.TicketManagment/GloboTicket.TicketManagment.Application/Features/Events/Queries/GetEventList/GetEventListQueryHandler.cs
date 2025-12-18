using AutoMapper;
using GloboTicket.TicketManagment.Application.Contracts.Persistence;
using GloboTicket.TicketManagment.Application.Dtos;
using GloboTicket.TicketManagment.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagment.Application.Features.Events.Queries.GetEventList
{
    public class GetEventListQueryHandler : IRequestHandler<GetEventListQuery, List<EventDto>>
    {
        private readonly IAsyncRepository<Event> _eventRepository;
        private readonly IMapper _mapper;

        public GetEventListQueryHandler(IMapper mapper, IAsyncRepository<Event> eventRepository) =>
            (_eventRepository, _mapper) = (eventRepository, mapper);

        public async Task<List<EventDto>> Handle(GetEventListQuery request, CancellationToken cancellationToken)
        {
            var entity = (await _eventRepository.GetAllAsync()).OrderBy(x => x.Date);
            return _mapper.Map<List<EventDto>>(entity);
        }
    }
}
