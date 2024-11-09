using Nancy.Json;
using System.Net;
using Weather.Dto;
using Weather.ServiceInterface;

namespace Weather.Services
{
    public class WeatherForecastServices : IWeatherForecastServices
    {
        public async Task<AccuWeatherLocationResultDto> AccuWeatherLocationResult(AccuWeatherLocationResultDto dto)
        {
            string APIKey = "Ylo9qEmuGDlDcPTgMTImricoQ4A0itQq";
            string url = $"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={APIKey}&q={dto.City}";
            //127964

            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                List<AccuWeatherLocationRootDto> accuResult = new JavaScriptSerializer().Deserialize<List<AccuWeatherLocationRootDto>>(json);

                dto.City = accuResult[0].LocalizedName;
                dto.Key = accuResult[0].Key;

            }

            

            return dto;
        }
        public async Task<WeatherResultDto> WeatherResult(WeatherResultDto dto, AccuWeatherLocationResultDto dto1)
        {
            
            await AccuWeatherLocationResult(dto1);

            string urlWeather = $"http://dataservice.accuweather.com/forecasts/v1/daily/1day/127964?apikey=Ylo9qEmuGDlDcPTgMTImricoQ4A0itQq&metric=true";
            
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(urlWeather);
                WeatherRootDto result = new JavaScriptSerializer().Deserialize<WeatherRootDto>(json);
                
                var dailyForecast = result.DailyForecasts[0];

                dto.EffectiveDate = result.Headline.EffectiveDate.ToString("yyyy-MM-dd");
                dto.EffectiveEpochDate = result.Headline.EffectiveEpochDate;
                dto.Severity = result.Headline.Severity;
                dto.Text = result.Headline.Text;
                dto.Date = dailyForecast.Date;
                dto.Temperature = dailyForecast.Temperature;
                dto.Day = dailyForecast.Day;
                dto.Night = dailyForecast.Night;
                dto.Sources = dailyForecast.Sources;
                dto.MobileLink = dailyForecast.MobileLink;
                dto.Link = dailyForecast.Link;
                dto.Icon = dailyForecast.Day.Icon;
                dto.IconPhrase = dailyForecast.Day.IconPhrase;
                dto.HasPrecipitation = dailyForecast.Day.HasPrecipitation;
                

            }
            return dto;
        }
    }
}
