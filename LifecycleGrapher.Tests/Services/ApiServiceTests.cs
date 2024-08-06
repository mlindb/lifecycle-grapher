using Xunit;
using LifecycleGrapher.Services;

namespace LifecycleGrapher.Tests.Services
{
    public class ApiServiceTests
    {
        [Fact]
        public void Endpoint_ShouldReturnValidEndpoint()
        {
            // Arrange
            var url = "https://tacton-server.com";
            var user = "user";
            var pwd = "pwd123";
            var obj = "Account";
            var apiService = new ApiService(url, user, pwd, obj);


            // Act
            var result = apiService.Endpoint;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("https://tacton-server.com/api-v2.2/account/describe", result);
        }
    }
}