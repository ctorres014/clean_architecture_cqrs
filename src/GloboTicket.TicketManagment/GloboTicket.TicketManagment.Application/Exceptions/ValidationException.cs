using FluentValidation.Results;

namespace GloboTicket.TicketManagment.Application.Exceptions
{
    public class ValidationException: Exception
    {
        public List<string> ValidationErrors { get; } = new List<string>();
        public ValidationException(ValidationResult validationResult)
        {
            foreach (var item in validationResult.Errors)
            {
                ValidationErrors.Add(item.ErrorMessage);
            }
        }
    }
}
