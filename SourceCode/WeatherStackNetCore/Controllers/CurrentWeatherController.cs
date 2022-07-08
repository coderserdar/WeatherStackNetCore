using System.Runtime.Serialization.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using WeatherStackNetCore.Models;
using WeatherStackNetCore.Utils;

namespace WeatherStackNetCore.Controllers;

public class CurrentWeatherController : Controller
{
    public IActionResult Index()
    {
        var model = new CurrentWeatherViewModel();
        return View(model);
    }

    [HttpPost]
    public async Task<CurrentWeather?> GetCurrentWeather(string query, string unit, string language)
    {
        var API_key = "7aae0d0b8034def58abb3a31f6e317b0";
        
        var http = new HttpClient();
        http.Timeout = new TimeSpan(0, 0, 30);
        var requestString = "http://api.weatherstack.com/" + $"current?access_key={API_key}&query={query}";
        if (!string.IsNullOrEmpty(unit))
            requestString += $"&unit={unit}";
        if (!string.IsNullOrEmpty(language))
            requestString += $"&language={language}";
        var response = await http.GetAsync(requestString);
        var result = await response.Content.ReadAsStringAsync();

        var serializer = new DataContractJsonSerializer(typeof(CurrentWeather));

        var memorystream = new MemoryStream(Encoding.UTF8.GetBytes(result));
        var data = (CurrentWeather)serializer.ReadObject(memorystream);

        return data;
    }
}