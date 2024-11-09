using Weather.Dto;

namespace Weather.ServiceInterface
{
    public interface IWeatherForecastServices
    {
        Task<AccuWeatherLocationResultDto> AccuWeatherLocationResult(AccuWeatherLocationResultDto dto);
        Task<WeatherResultDto> WeatherResult(WeatherResultDto dto, AccuWeatherLocationResultDto dto1);
    }
}
