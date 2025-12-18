using GloboTicket.TicketManagment.Application.Dtos;
using MediatR;

namespace GloboTicket.TicketManagment.Application.Features.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQuery : IRequest<List<CategoryDto>>
    {
    }
}
