using GloboTicket.TicketManagment.Application.Dtos;
using GloboTicket.TicketManagment.Application.Responses;

namespace GloboTicket.TicketManagment.Application.Features.Categories.Command.CreateCategory
{
    public class CreateCategoryCommandResponse: BaseResponse
    {
        public CreateCategoryCommandResponse(): base()
        {
            
        }

        public CategoryDto Category { get; set; } = default!;
    }
}
