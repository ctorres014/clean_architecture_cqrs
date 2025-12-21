using FluentValidation;

namespace GloboTicket.TicketManagment.Application.Features.Categories.Command.CreateCategory
{
    public class CreateCategoryCommandValidator: AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Name is not empty");
        }
    }
}
