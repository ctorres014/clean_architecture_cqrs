using AutoMapper;
using GloboTicket.TicketManagment.Application.Contracts;
using GloboTicket.TicketManagment.Application.Dtos;
using GloboTicket.TicketManagment.Application.Features.Categories.Queries.GetCategoriesList;
using GloboTicket.TicketManagment.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagment.Application.Features.Categories.Queries
{
    public class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<CategoryDto>>
    {
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesListQueryHandler(IAsyncRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var categories = (await _categoryRepository.GetAllAsync()).OrderBy(x => x.Name);
            return _mapper.Map<List<CategoryDto>>(categories);
        }
    }
}
