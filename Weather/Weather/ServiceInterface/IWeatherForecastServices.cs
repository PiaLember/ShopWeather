using Weather.Dto;

namespace Weather.ServiceInterface
{
    public interface IWeatherForecastServices
    {
        Task<AccuWeatherLocationResultDto> AccuWeatherResult(AccuWeatherLocationResultDto dto);
    }
}
