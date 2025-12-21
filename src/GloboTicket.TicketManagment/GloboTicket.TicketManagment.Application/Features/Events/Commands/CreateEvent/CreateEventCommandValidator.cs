using FluentValidation;
using GloboTicket.TicketManagment.Application.Contracts.Persistence;

namespace GloboTicket.TicketManagment.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator: AbstractValidator<CreateEventCommand>
    {
        private readonly IEventRepository _eventRepositoty;
        public CreateEventCommandValidator(IEventRepository eventRepository)
        {
            _eventRepositoty = eventRepository;

            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(e => e.Date)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(DateTime.Now);

            RuleFor(e => e)
                .MustAsync(EventNameAndDateUnique)
                .WithMessage("An event with the same name and date already exists");

            RuleFor(e => e.Price)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .GreaterThan(0);
        }

        private async Task<bool> EventNameAndDateUnique(CreateEventCommand command, CancellationToken token)
        {
            return !(await _eventRepositoty.IsEventEnameAndDateUnique(command.Name, command.Date));
        }
    }
}
