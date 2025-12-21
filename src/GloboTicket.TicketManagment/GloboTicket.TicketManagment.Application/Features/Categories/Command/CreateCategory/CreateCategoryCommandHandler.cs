using AutoMapper;
using GloboTicket.TicketManagment.Application.Contracts.Persistence;
using GloboTicket.TicketManagment.Application.Dtos;
using GloboTicket.TicketManagment.Domain.Entities;
using MediatR;

namespace GloboTicket.TicketManagment.Application.Features.Categories.Command.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
    {
        private readonly IAsyncRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;
        public CreateCategoryCommandHandler(IAsyncRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var createCommandResponse = new CreateCategoryCommandResponse();

            //Implement Validation
            var validator = new CreateCategoryCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            // Apply Custom Command Response
            if (!validationResult.IsValid)
            {
                createCommandResponse.IsSuccess = false;
                foreach (var item in validationResult.Errors)
                {
                    createCommandResponse.Errors.Add(item.ErrorMessage);
                }
            }


            var category = new Category { Name = request.Name };
            category = await _categoryRepository.AddAsync(category);
            createCommandResponse.Category = _mapper.Map<CategoryDto>(category);
            return createCommandResponse;
        }
    }
}
