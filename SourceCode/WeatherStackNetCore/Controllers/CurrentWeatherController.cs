using System.Runtime.Serialization.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using WeatherStackNetCore.Models;
using WeatherStackNetCore.Utils;

namespace WeatherStackNetCore.Controllers;

public class CurrentWeatherController : Controller
{
    /// <summary>
    /// Config element
    /// </summary>
    private IConfiguration configuration;

    /// <summary>
    /// This is the constructor of controller
    /// </summary>
    /// <param name="config"></param>
    public CurrentWeatherController(IConfiguration config)
    {
        // this is used to get some key values from appSettings.Json
        configuration = config;
    }
    
    /// <summary>
    /// This is used to show Current Weather search page
    /// </summary>
    /// <returns>Current Weather search page</returns>
    public IActionResult Index()
    {
        var model = new CurrentWeatherViewModel();
        return View(model);
    }

    /// <summary>
    /// This method is used to make WeaherStack Current API call
    /// And bring the result to the screen
    /// </summary>
    /// <param name="query">General Parameter (Like City Name, County Name etc)</param>
    /// <param name="unit">Unit Parameter</param>
    /// <param name="language">Language Parameter (You shouldn't fill this parameter if your key is free version)</param>
    /// <returns>Current Weather Info</returns>
    [HttpPost]
    public async Task<CurrentWeather?> GetCurrentWeather(string query, string unit, string language)
    {
        try
        {
            var apiKey = configuration.GetValue<string>("API_Key"); 
        
            var httpClient = new HttpClient();
            httpClient.Timeout = new TimeSpan(0, 0, 30);
        
            var requestString = "http://api.weatherstack.com/" + $"current?access_key={apiKey}&query={query}";
            if (!string.IsNullOrEmpty(unit))
                requestString += $"&unit={unit}";
            if (!string.IsNullOrEmpty(language))
                requestString += $"&language={language}";
        
            var response = await httpClient.GetAsync(requestString);
            var result = await response.Content.ReadAsStringAsync();

            var serializer = new DataContractJsonSerializer(typeof(CurrentWeather));
            var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var currentWeather = (CurrentWeather)serializer.ReadObject(memoryStream)!;

            return currentWeather;
        }
        catch (Exception e)
        {
            return null;
        }
    }
}