using TestWebAPI.Controllers;
using TestWebAPI.Model;
using TestWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CondingTestUnitTest
{
    public class UserControllerTest
    {
        [Fact]
        public void Create_ValidModel_ReturnsCreatedResult()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var userController = new UserController(userServiceMock.Object);

            var userModel = new UserModel { FirstName = "Adharv", LastName = "Thakur" };

            // Act
            var result = userController.Create(userModel) as CreatedAtActionResult;

            // Assert
            userServiceMock.Verify(x => x.SaveUserToFile(userModel), Times.Once);

            Assert.NotNull(result);
            Assert.Equal(StatusCodes.Status201Created, result.StatusCode);
        }

        [Theory]
        [InlineData(null, "Thakur")]
        [InlineData("Adharv", null)]
        [InlineData(null, null)]
        [InlineData("", "Thakur")]
        [InlineData("Adharv", "")]
        [InlineData("", "")]
        public void Create_InvalidModel_ThrowsBadRequestException(string firstName, string lastName)
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            var userController = new UserController(userServiceMock.Object);

            var userModel = new UserModel { FirstName = firstName, LastName = lastName };

            // Act & Assert
            var ex = Assert.Throws<BadHttpRequestException>(() => userController.Create(userModel));

            Assert.Equal(StatusCodes.Status400BadRequest, ex.StatusCode);
            Assert.Contains("Invalid data. Both first name and last name are required.", ex.Message);
        }

    }
}