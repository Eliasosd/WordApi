using WordApi.Controllers;
using Moq;
using WordApi.Services;
using Microsoft.AspNetCore.Mvc;
using WordApi.Interfaces;


namespace WordCount
{
    public class UnitTest1
    {
        [Fact]
        public void Post_EmptyInput_ReturnsBadRequest()
        {
            //Arrange
            var mockService = new Mock<IWordCountService>();
            var controller = new WordCountController(mockService.Object);
            string testString = "";

            //Act
            var result = controller.Post(testString);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Post_WhiteSpace_ReturnsBadRequest()
        {
            //Arrange
            var mockService = new Mock<IWordCountService>();
            var controller = new WordCountController(mockService.Object);
            string testString = " ";

            //Act
            var result = controller.Post(testString);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void Post_StringFruits_ReturnsCorrectResult()
        {
            //Arrange
            var mockService = new Mock<IWordCountService>();
            var controller = new WordCountController(mockService.Object);
            string testString = "Banan Melon Kiwi Citron Banan";

            mockService.Setup(s => s.CountWords(testString)).Returns(new Dictionary<string, int>
            {
                { "Banan", 2 },
                { "Melon", 1 },
                { "Kiwi", 1 },
                { "Citron", 1 }
            });

            //Act
            var result = controller.Post(testString) as OkObjectResult;

            //Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            var data = Assert.IsType<Dictionary<string, int>>(result.Value);
            Assert.Equal(4, data.Count);
            Assert.Equal(2, data["Banan"]);
            Assert.Equal(1, data["Melon"]);
            Assert.Equal(1, data["Kiwi"]);
            Assert.Equal(1, data["Citron"]);
        }
    }
}