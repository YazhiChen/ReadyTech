namespace ReadyTech.Client
{
    public interface IWeatherApiClient
    {
        Task<double> GetCurrentTemp();
    }
}
