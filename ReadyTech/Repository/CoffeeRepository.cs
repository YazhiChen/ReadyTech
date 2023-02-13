using ReadyTech.Models;

namespace ReadyTech.Repository
{
    public class CoffeeRepository: ICoffeeRepository
    {
        private readonly ReadyTechDbContext _context;

        public CoffeeRepository(ReadyTechDbContext context)
        {
            _context = context;
        }    

        public ResponseDTO BrewCoffee(double currentTemp)
        {
            ResponseDTO response = new();
            if (currentTemp > 30)
                response.Message = "Your refreshing iced coffee is ready";
            else
                response.Message = "Your piping hot coffee is ready";
            response.Prepared = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:sszzz");
            return response;
        }
    }
}
