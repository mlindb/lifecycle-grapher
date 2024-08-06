using Xunit;
using System.IO;
using LifecycleGrapher.Utilities;

namespace LifecycleGrapher.Tests.Utilities
{
    public class FileHelperTests
    {
        [Fact]
        public void WriteToFile_ShouldCreateFileWithContent()
        {
            // Arrange
            var filePath = "test_output.dot";
            var content = "digraph G {}";

            // Act
            FileHelper.WriteToFile(filePath, content);

            // Assert
            Assert.True(File.Exists(filePath));
            Assert.Equal(content, File.ReadAllText(filePath));

            // Clean up
            File.Delete(filePath);
        }
    }
}