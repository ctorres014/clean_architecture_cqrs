using AutoMapper;
using GlobalTicket.TicketManagment.Application.UnitTest.Mocks;
using GloboTicket.TicketManagment.Application.Contracts.Persistence;
using GloboTicket.TicketManagment.Application.Dtos;
using GloboTicket.TicketManagment.Application.Features.Categories.Queries.GetCategoryList;
using GloboTicket.TicketManagment.Application.Profiles;
using GloboTicket.TicketManagment.Domain.Entities;
using Moq;
using Shouldly;

namespace GlobalTicket.TicketManagment.Application.UnitTest;


public class GetCategoryListHandlerTest
{
    private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;
    private readonly IMapper _mapper;
    public GetCategoryListHandlerTest()
    {
        _mockCategoryRepository = RepositoryMock.GetCategoryRepository();
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<MappingProfile>();
        });
        _mapper = configurationProvider.CreateMapper();
    }

    // Rule in the name definition
    // MethodName_ShouldExpectedBehavior_StateUnderTest
    [Fact]
    public async Task GetCategory_ShouldAllCategory_GetAllCategory()
    {
        // Arrange → preparo todo
        var handler = new GetCategoryListHandler(_mockCategoryRepository.Object, _mapper);

        // Act     → ejecuto lo que pruebo
        var result = await handler.Handle(new GetCategoryListQuery(), CancellationToken.None);

        // Assert  → verifico el resultado
        result.ShouldBeOfType<List<CategoryDto>>();
        result.Count.ShouldBe(4);
    }
}
