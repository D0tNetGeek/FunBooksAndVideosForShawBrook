using System.Text;
using FunBooksAndVideosForShawBrook.Dto;
using Newtonsoft.Json;
using Xunit;

namespace FunBooksAndVideosForShawBrook.IntegrationTests
{
    public class OrderIntegrationTests : IClassFixture<TestingWebAppFactory<Program>>
    {
        private readonly HttpClient _client;
        public OrderIntegrationTests(TestingWebAppFactory<Program> factory) => _client = factory.CreateClient();

        private readonly string serviceBaseUrl = "http://localhost:5001/Orders";

        [Theory]
        [InlineData(999, 1, "Video Comprehensive First Aid Training", 20, "Digital", null)]
        [InlineData(999, 2, "Book The Girl on the train", 60, "Physical", null)]
        [InlineData(999, 3, "Book", 100, "Membership", "BookClub")]
        public async Task Given_List_Of_Products_When_Valid_Orer_Is_Placed_Then_Expect_Result_Is_Returned(int customerId, int productId, string productName, decimal price, string productType, string membershipType)
        {
            //Arrange
            var membershipProduct = new ProductDto { Id = productId, Name = productName, Price = price, ProductType = productType, MembershipType = membershipType};
            var order = new OrderDto { CustomerId = customerId, products = new List<ProductDto> { membershipProduct } };

            string json = JsonConvert.SerializeObject(order);

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = _client.PostAsync(serviceBaseUrl, httpContent);

            //Act
            var result = await response.Result.Content.ReadAsStringAsync();

            //Assert
            Assert.NotEmpty(result);

        }

        [Theory]
        [InlineData(888, 2, "Book The Girl on the train", 60, "FakePhysical")]
        [InlineData(888, 3, "Book", 100, "FakeMembership")]
        public Task Given_List_Of_Products_When_Invalid_Orer_Is_Placed_Then_Exception_Is_Returned(int customerId, int productId, string productName, decimal price, string productType)
        {
            //Arrange
            var membershipProduct = new ProductDto { Id = productId, Name = productName, Price = price, ProductType = productType};
            var order = new OrderDto { CustomerId = customerId, products = new List<ProductDto> { membershipProduct } };

            string json = JsonConvert.SerializeObject(order);

            //Act
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            //Assert
            var response = Assert.ThrowsAsync<AggregateException>(() => _client.PostAsync(serviceBaseUrl, httpContent));
            return Task.CompletedTask;
        }
    }
}