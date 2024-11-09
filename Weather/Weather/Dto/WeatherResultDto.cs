namespace Weather.Dto{
    public class WeatherResultDto{
        public Headline Headline { get; set; }
        public List<DailyForecast> DailyForecasts { get; set; }

        public DateTime Date { get; set; }
        public int EpochDate { get; set; }
        public Temperature Temperature { get; set; }
        public Day Day { get; set; }
        public Night Night { get; set; }
        public List<string> Sources { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }

        public int Icon { get; set; }
        public string IconPhrase { get; set; }
        public bool HasPrecipitation { get; set; }
        public string PrecipitationType { get; set; }
        public string PrecipitationIntensity { get; set; }

        public string EffectiveDate { get; set; }
        public int EffectiveEpochDate { get; set; }
        public int Severity { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
        public DateTime EndDate { get; set; }
        public int EndEpochDate { get; set; }

        public int Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }



        public Minimum Minimum { get; set; }
        public Maximum Maximum { get; set; }
    }
}