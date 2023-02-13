using ReadyTech.Client;
using ReadyTech.Repository;

namespace ReadyTech.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureWrapper(this IServiceCollection services)
        {
            services.AddScoped<ICoffeeRepository, CoffeeRepository>();
            services.AddHttpClient<IWeatherApiClient, WeatherApiClient>();
        }
    }
}
