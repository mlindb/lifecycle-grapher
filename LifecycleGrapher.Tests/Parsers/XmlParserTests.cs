using Xunit;
using LifecycleGrapher.Parsers;
using LifecycleGrapher.Models;

namespace LifecycleGrapher.Tests.Parsers
{
    public class XmlParserTests
    {
        [Fact]
        public void ParseXmlData_ShouldReturnValidModel()
        {
            // Arrange
            var xmlParser = new XmlParser();
            var xmlData = "<resource><attributes><attribute name=\"name\" value=\"myAttr\"/></attributes></resource>"; // Example XML data

            // Act
            var result = xmlParser.ParseData(xmlData);

            // Assert
            Assert.NotNull(result);
            // Add additional assertions based on the structure of ApiResponseModel
        }
    }
}