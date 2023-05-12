using Newtonsoft.Json;

namespace Climate2.Models
{
    public class WeatherData
    {
        [JsonProperty("main")]
        public MainData Main { get; set; }

        [JsonProperty("weather")]
        public WeatherInfo[] Weather { get; set; }
    }

    public class MainData
    {
        [JsonProperty("temp")]
        public double Temperature { get; set; }

        [JsonProperty("temp_min")]
        public double MinTemperature { get; set; }

        [JsonProperty("temp_max")]
        public double MaxTemperature { get; set; }

        [JsonProperty("humidity")]
        public int Humidity { get; set; }
    }

    public class WeatherInfo
    {
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }
    }
}