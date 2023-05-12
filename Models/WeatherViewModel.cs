using Climate2.Models;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace Climate2.ViewModels
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        private const string API_KEY = "ee1b8eaa308cd9f07b324f8b805d6fe1";
        private const string API_BASE_URL = "https://api.openweathermap.org/data/2.5/weather";

        private string _cityName;
        private double _temperature;
        private double _minTemperature;
        private double _maxTemperature;
        private int _humidity;
        private string _description;
        private string _iconUrl;
        private string _status;

        public event PropertyChangedEventHandler PropertyChanged;

        public string CityName
        {
            get => _cityName;
            set
            {
                if (_cityName != value)
                {
                    _cityName = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CityName)));
                }
            }
        }

        public double Temperature
        {
            get => _temperature;
            set
            {
                if (_temperature != value)
                {
                    _temperature = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Temperature)));
                }
            }
        }

        public double MinTemperature
        {
            get => _minTemperature;
            set
            {
                if (_minTemperature != value)
                {
                    _minTemperature = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MinTemperature)));
                }
            }
        }

        public double MaxTemperature
        {
            get => _maxTemperature;
            set
            {
                if (_maxTemperature != value)
                {
                    _maxTemperature = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MaxTemperature)));
                }
            }
        }

        public int Humidity
        {
            get => _humidity;
            set
            {
                if (_humidity != value)
                {
                    _humidity = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Humidity)));
                }
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                if (_description != value)
                {
                    _description = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
                }
            }
        }

        public string IconUrl
        {
            get => _iconUrl;
            set
            {
                if (_iconUrl != value)
                {
                    _iconUrl = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IconUrl)));
                }
            }
        }

        public string Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
                }
            }
        }

        public async Task GetWeatherDataAsync()
        {
            using (var client = new HttpClient())
            {
                var requestUrl = $"{API_BASE_URL}?q={CityName}&appid={API_KEY}&units=metric";
                var response = await client.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var weatherData = JsonConvert.DeserializeObject<WeatherData>(jsonResponse);

                    Temperature = weatherData.Main.Temperature;
                    MinTemperature = weatherData.Main.MinTemperature;
                    MaxTemperature = weatherData.Main.MaxTemperature;
                    Humidity = weatherData.Main.Humidity;
                    Description = weatherData.Weather[0].Description;
                    IconUrl = $"https://openweathermap.org/img/w/{weatherData.Weather[0].Icon}.png";
                    Status = "Success";
                }
                else
                {
                    Status = "Error";
                }
            }
        }
    }
}
