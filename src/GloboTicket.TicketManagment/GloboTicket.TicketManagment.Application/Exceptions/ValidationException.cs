using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagment.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> validationErrors { get; set; }

        public ValidationException(ValidationResult validation) 
        { 
            validationErrors= new List<string>();

            foreach (var validationError in validation.Errors)
            {
                validationErrors.Add(validationError.ErrorMessage);
            }
        }

    }
}
