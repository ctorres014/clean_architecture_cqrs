using AutoMapper;
using GloboTicket.TicketManagment.Application.Contracts.Persistence;
using GloboTicket.TicketManagment.Application.Dtos;
using MediatR;

namespace GloboTicket.TicketManagment.Application.Features.Categories.Queries.GetCategoryListWithEvent
{
    public class GetCategoryListWithEventHandler : IRequestHandler<GetCategoryListWithEventQuery, List<CategotyEventDto>>
    {
        private readonly ICategoryRepository _categoryEventRepository;
        private readonly IMapper _mapper;

        public GetCategoryListWithEventHandler(ICategoryRepository categoryEventRepository, IMapper mapper)
        {
            _categoryEventRepository = categoryEventRepository;
            _mapper = mapper;
        }

        public async Task<List<CategotyEventDto>> Handle(GetCategoryListWithEventQuery request, CancellationToken cancellationToken)
        {
            var categoryEventList = await _categoryEventRepository.GetCategoriesWithEvents(request.IncludeHistory);
            return _mapper.Map<List<CategotyEventDto>>(categoryEventList);
        }
    }
}
