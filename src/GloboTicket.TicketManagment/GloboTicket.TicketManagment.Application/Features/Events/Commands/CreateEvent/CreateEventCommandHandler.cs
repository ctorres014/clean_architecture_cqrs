using AutoMapper;
using GloboTicket.TicketManagment.Application.Contracts;
using GloboTicket.TicketManagment.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagment.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository<Event> _eventRepository;
        private readonly IMapper _mapper;

        public CreateEventCommandHandler(IEventRepository<Event> eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Event>(request);
            return await _eventRepository.AddAsync(entity);
        }
    }
}
