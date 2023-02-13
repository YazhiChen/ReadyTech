using Newtonsoft.Json.Linq;

namespace ReadyTech.Client
{
    public class WeatherApiClient : IWeatherApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<WeatherApiClient> _logger;
        private readonly string apiKey;

        public WeatherApiClient (HttpClient httpClient, ILogger<WeatherApiClient> logger, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _logger = logger;
            apiKey = configuration["OpenWeatherAPIKey"];
        }

        public async Task<double> GetCurrentTemp()
        {
            double lat = -37.663712;
            double lon = 144.844788;
            string url = $"https://api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={apiKey}&units=metric";

            var httpResponse = await _httpClient.GetAsync(url);
            try
            {
                httpResponse.EnsureSuccessStatusCode();
                string? stringResponse = await httpResponse.Content.ReadAsStringAsync();
                dynamic data = JObject.Parse(stringResponse);
                return  data.main.temp;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while getting current Temperature", ex.Message);              
                throw;
            }
        }
    }
}

