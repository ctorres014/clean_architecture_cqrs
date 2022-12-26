using GloboTicket.TicketManagment.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagment.Application.Features.Categories.Queries.GetCategoriesWithEvents
{
    public class GetCategoriesWithEventsQueryHandler : IRequestHandler<GetCategoriesWithEventsQuery, CategoryEventList>
    {
        public Task<CategoryEventList> Handle(GetCategoriesWithEventsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
