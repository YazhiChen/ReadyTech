using ReadyTech.Models;

namespace ReadyTech.Repository
{
    public interface ICoffeeRepository
    {
        ResponseDTO BrewCoffee(double currentTemp);
    }
}
