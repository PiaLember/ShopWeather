using Nancy.Json;
using System.Net;
using Weather.Dto;
using Weather.ServiceInterface;

namespace Weather.Services
{
    public class WeatherForecastServices : IWeatherForecastServices
    {
        public async Task<AccuWeatherLocationResultDto> AccuWeatherResult(AccuWeatherLocationResultDto dto)
        {
            string APIKey = "Ylo9qEmuGDlDcPTgMTImricoQ4A0itQq";
            string url = $"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={APIKey}&q={dto.City}";


            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                List<AccuWeatherLocationRootDto> accuResult = new JavaScriptSerializer().Deserialize<List<AccuWeatherLocationRootDto>>(json);

                dto.City = accuResult[0].LocalizedName;
                dto.Key = accuResult[0].Key;

            }

            string urlWeather = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/{dto.Key}?apikey={APIKey}q&metric=true";

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(urlWeather);
                WeatherRootDto accuResult = new JavaScriptSerializer().Deserialize<WeatherRootDto>(json);

                var dailyForecast = accuResult.DailyForecasts[0];

                dto.EffectiveDate = accuResult.Headline.EffectiveDate.ToString("yyyy-MM-dd");
                dto.EffectiveEpochDate = accuResult.Headline.EffectiveEpochDate;
                dto.Date = dailyForecast.Date;
                dto.Temperature = dailyForecast.Temperature;

            }

            return dto;
        }
    }
}
