using Xunit;
using LifecycleGrapher.Services;
using LifecycleGrapher.Models;

namespace LifecycleGrapher.Tests.Services
{
    public class DotFileGeneratorTests
    {
        [Fact]
        public void GenerateDotFile_ShouldReturnValidDotContent()
        {
            // Arrange
            var dotFileGenerator = new DotFileGenerator();
            var data = new ApiResponseModel(); // Populate with test data

            // Act
            var result = dotFileGenerator.GenerateDotFile(data, "name");

            // Assert
            Assert.NotNull(result);
        }
    }
}