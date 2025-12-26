using GlobalTicket.TicketManagment.Api.IntegrationTest.Base;
using GloboTicket.TicketManagment.Application.Dtos;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System.Text.Json;


namespace GlobalTicket.TicketManagment.Api.IntegrationTest.Controllers
{
    public class CategoryControllerTest: IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly CustomWebApplicationFactory<Program> _factory;
        public CategoryControllerTest(CustomWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }
        [Fact]
        public async Task GetAllCategories_ShouldAllCategories_ReturnSucccessResult()
        {
            // Arrange
            //var client = _factory.GetAnonymousClient();
            var client = _factory.CreateClient();
            // Act
            var response = await client.GetAsync("/api/Category/all");
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<CategoryDto>>(responseString);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

        }
        [Fact]
        public async Task GetAllCategories_ShouldAllCategories_NotEmpyResult()
        {
            // Arrange
            var client = _factory.CreateClient();
            // Act
            var response = await client.GetAsync("/api/Category/all");
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<CategoryDto>>(responseString);

            // Assert
            Assert.IsType<List<CategoryDto>>(result);
            Assert.NotEmpty(result);

        }
    }
}
