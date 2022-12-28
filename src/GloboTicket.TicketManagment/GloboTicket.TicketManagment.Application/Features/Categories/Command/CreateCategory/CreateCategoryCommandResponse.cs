using FluentValidation.Results;
using GloboTicket.TicketManagment.Application.Dtos;
using GloboTicket.TicketManagment.Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagment.Application.Features.Categories.Command.CreateCategory
{
    public class CreateCategoryCommandResponse : BaseResponse
    {
        private CreateCategoryCommandResponse(bool success, CategoryDto category) : base() 
        {
            Success = success;
            Category = category;
        }
        private CreateCategoryCommandResponse(bool success, ValidationResult validationErrors) : base() 
        { 
            Success= success;
            ValidationErrors = new List<string>();
            foreach (var error in validationErrors.Errors)
            {
                ValidationErrors.Add(error.ErrorMessage);
            }

        }

        private CategoryDto Category { get; set; }

        public static CreateCategoryCommandResponse CreateCommandResponse(bool success, ValidationResult validationErrors, CategoryDto? category) 
        { 
            if(!success)
            {
                return new CreateCategoryCommandResponse(success, validationErrors);
            }
            return new CreateCategoryCommandResponse(success, category);
        }
    }
}
