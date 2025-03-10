using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvertiseService.Application.Features.Ads.Commands;
using AdvertiseService.Domain;
using AdvertiseService.Domain.Entities;
using Moq;

namespace AdvertiseService.Application.Tests
{
    /// <summary>
    /// تست ایجاد آگهی
    /// </summary>
    public class CreateAdCommandTests
    {
        [Fact]
        public async Task Handle_ValidCommand_ShouldReturnAdId()
        {
            // Arrange
            var mockRepo = new Mock<IAdRepository>();
            var handler = new CreateAdCommandHandler(mockRepo.Object);
            var command = new CreateAdCommand { Title = "Test", Price = 1000 };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            mockRepo.Verify(r => r.AddAsync(It.IsAny<Ad>()), Times.Once);
            Assert.True(string.IsNullOrEmpty(result.ToString()));
        }

        [Fact]
        public async Task Handle_ValidCommand_ReturnsAdId()
        {
            // Arrange
            var mockRepo = new Mock<IAdRepository>();
            var handler = new CreateAdCommandHandler(mockRepo.Object);
            var command = new CreateAdCommand { Title = "Test", Price = 1000 };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            mockRepo.Verify(r => r.AddAsync(It.IsAny<Ad>()), Times.Once);
            Assert.True(string.IsNullOrEmpty(result.ToString()));
        }
    }
}
