using GloboTicket.TicketManagment.Application.Contracts.Persistence;
using GloboTicket.TicketManagment.Domain.Entities;
using Moq;

namespace GlobalTicket.TicketManagment.Application.UnitTest.Mocks
{
    public static class RepositoryMock
    {
        public static Mock<IAsyncRepository<Category>> GetCategoryRepository()
        {
            var concertGuid = Guid.Parse("{B0788D2F-8003-43C1-92A4-EDC76A7C5DDE}");
            var musicalGuid = Guid.Parse("{FE9A5E7D-5D6C-4F3B-8D9E-8E1C2D5C8BCE}");
            var playGuid = Guid.Parse("{7D4E4B6C-2A1F-4F3E-9F8E-3C2B1A0D9E8F}");
            var conferenceGuid = Guid.Parse("{A1B2C3D4-E5F6-4789-ABCD-1234567890AB}");

            var categories = new List<Category>
            {
               new Category
                {
                    CategoryId = concertGuid,
                    Name = "Concerts",
                    CreatedBy = "System",
                    CreateDate = DateTime.Now
                },
                new Category
                {
                    CategoryId = musicalGuid,
                    Name = "Musicals",
                    CreatedBy = "System",
                    CreateDate = DateTime.Now
                },
                new Category
                {
                    CategoryId = playGuid,
                    Name = "Plays",
                    CreatedBy = "System",
                    CreateDate = DateTime.Now
                },
                new Category
                {
                    CategoryId = conferenceGuid,
                    Name = "Conferences",
                    CreatedBy = "System",
                    CreateDate = DateTime.Now
                }
            };

            var mockCategoryRepository = new Mock<IAsyncRepository<Category>>();
            mockCategoryRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(categories);

            mockCategoryRepository.Setup(r => r.AddAsync(It.IsAny<Category>())).ReturnsAsync(
                (Category category) =>
                {
                    categories.Add(category);
                    return category;
                });
            return mockCategoryRepository;
        }
    }
}
