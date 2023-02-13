using Microsoft.AspNetCore.Mvc;
using ReadyTech.Client;
using ReadyTech.Models;
using ReadyTech.Repository;

namespace ReadyTech.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeOrdersController : ControllerBase
    {
        private readonly ReadyTechDbContext context;
        private readonly ICoffeeRepository coffeeRepository;
        private readonly IWeatherApiClient weatherApiClient;
        private static int requestCount = 0;

        public CoffeeOrdersController(ReadyTechDbContext dbContext, ICoffeeRepository repository, IWeatherApiClient apiClient)
        {
            context = dbContext;
            coffeeRepository = repository;
            weatherApiClient = apiClient;
        }

        [HttpGet, Route("brew-coffee")]
        public async Task<IActionResult> BrewCoffeeAsync()
        {
            if ((DateTime.Now.Month == 4) && (DateTime.Now.Day == 1))
            {
                return new StatusCodeResult(418);
            }
            double currentTemp = await weatherApiClient.GetCurrentTemp();
            requestCount++;
            if(requestCount == 5)
            {
                requestCount = 0;
                return new StatusCodeResult(503);
            }
            return Ok(coffeeRepository.BrewCoffee(currentTemp));
        }
    }
}
