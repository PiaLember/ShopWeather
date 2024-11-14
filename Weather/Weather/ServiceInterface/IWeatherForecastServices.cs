using Weather.Dto;

namespace Weather.ServiceInterface
{
    public interface IWeatherForecastServices
    {
        Task<AccuWeatherLocationResultDto> WeatherResult(AccuWeatherLocationResultDto dto);
    }
}
