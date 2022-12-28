using AutoMapper;
using GloboTicket.TicketManagment.Application.Contracts;
using GloboTicket.TicketManagment.Application.Dtos;
using GloboTicket.TicketManagment.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagment.Application.Features.Categories.Command.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(IAsyncRepository<Category> categoryRepository, IMapper mapper) 
        { 
            _categoryRepository= categoryRepository;
            _mapper= mapper;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var validtor = new CreateCategoryCommandValidator();
            var validatorResult = await validtor.ValidateAsync(request);

            if (validatorResult.Errors.Count> 0) 
            {
                return CreateCategoryCommandResponse.CreateCommandResponse(false, validatorResult, null);
            }
            // Create object category by builder method
            // call repository for add method
            // use mapper for get object type dto
            // create category response
            var category = new Category() { Name = request.Name };
            await _categoryRepository.AddAync(category);
            return CreateCategoryCommandResponse.CreateCommandResponse(true, validatorResult, _mapper.Map<CategoryDto>(category));
        }
    }
}
