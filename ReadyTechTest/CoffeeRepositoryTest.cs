using Castle.Core.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using ReadyTech.Client;
using ReadyTech.Controllers;
using ReadyTech.Models;
using ReadyTech.Repository;

namespace ReadyTech.Test
{
    public class CoffeeRepositoryTest
    {
        private readonly ReadyTechDbContext context;
        private readonly Mock<ICoffeeRepository> mockRepo;
        private readonly Mock<IWeatherApiClient> mockIApiClient;
        private readonly CoffeeOrdersController coffeeOrdersController;

        public CoffeeRepositoryTest()
        {
            mockRepo = new Mock<ICoffeeRepository>();
            var options = new DbContextOptionsBuilder<ReadyTechDbContext>()
              .UseInMemoryDatabase(databaseName: "ReadyTech")
              .Options;
            context = new ReadyTechDbContext(options);
            mockIApiClient = new Mock<IWeatherApiClient>();
            coffeeOrdersController = new CoffeeOrdersController(context, mockRepo.Object, mockIApiClient.Object);
        }

        [Fact]
        public async Task GivenTheClientSendMultipleRequests_503StatusCodeShouldReturned_Every5RequestsAsync()
        {
            //Arrange
            ResponseDTO response = new();
            response.Message = "Your refreshing iced coffee is ready";
            response.Prepared = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:sszzz");

            mockRepo.Setup(repo => repo.BrewCoffee(It.IsAny<double>())).Returns(response);
            int requestCounter = 20;
            for (int i = 1; i <= requestCounter; i++)
            {
                //action
                var result = await coffeeOrdersController.BrewCoffeeAsync();
                //assert
                if (i % 5 == 0)
                {
                    StatusCodeResult objectResponse = Assert.IsType<StatusCodeResult>(result);
                    Assert.Equal(503, objectResponse.StatusCode);
                }
                else
                {
                    OkObjectResult okResponse = Assert.IsType<OkObjectResult>(result);
                    Assert.Equal(200, okResponse.StatusCode);
                    var returnValue = Assert.IsType<ResponseDTO>(okResponse.Value);
                    Assert.True(response.Equals(returnValue));
                }
            }
        }
    }
}


