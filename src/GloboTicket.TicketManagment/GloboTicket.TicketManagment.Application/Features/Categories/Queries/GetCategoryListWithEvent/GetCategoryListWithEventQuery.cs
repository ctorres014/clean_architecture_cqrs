using GloboTicket.TicketManagment.Application.Dtos;
using MediatR;

namespace GloboTicket.TicketManagment.Application.Features.Categories.Queries.GetCategoryListWithEvent
{
    public class GetCategoryListWithEventQuery : IRequest<List<CategoryEventDto>>
    {
        public bool IncludeHistory { get; set; }
        }
}
