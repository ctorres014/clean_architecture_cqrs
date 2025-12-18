using AutoMapper;
using GloboTicket.TicketManagment.Application.Contracts.Persistence;
using GloboTicket.TicketManagment.Application.Dtos;
using GloboTicket.TicketManagment.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagment.Application.Features.Categories.Queries.GetCategoryList
{
    public class GetCategoryListHandler : IRequestHandler<GetCategoryListQuery, List<CategoryDto>>
    {
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;
        public GetCategoryListHandler(IAsyncRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<List<CategoryDto>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();
            return _mapper.Map<List<CategoryDto>>(categories);
        }
    }
}
