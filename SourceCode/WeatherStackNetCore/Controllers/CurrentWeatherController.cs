using System.Runtime.Serialization.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using WeatherStackNetCore.Models;
using WeatherStackNetCore.Utils;

namespace WeatherStackNetCore.Controllers;

/// <summary>
/// This controller is used to
/// Call API function which is about Current Weather Info searching
/// </summary>
public class CurrentWeatherController : Controller
{
    /// <summary>
    /// Config element
    /// </summary>
    private readonly IConfiguration _configuration;

    /// <summary>
    /// This is the constructor of controller
    /// </summary>
    /// <param name="config"></param>
    public CurrentWeatherController(IConfiguration config)
    {
        // this is used to get some key values from appSettings.Json
        _configuration = config;
    }
    
    /// <summary>
    /// This is used to show Current Weather search page
    /// </summary>
    /// <returns>Current Weather search page</returns>
    public IActionResult IndexWithJQuery()
    {
        var model = new CurrentWeatherViewModel();
        return View(model);
    }
    
    /// <summary>
    /// This is used to show Current Weather search page
    /// </summary>
    /// <returns>Current Weather search page</returns>
    public IActionResult IndexWithModel(CurrentWeatherViewModel? model)
    {
        return View(model);
    }

    /// <summary>
    /// This method is used to make WeatherStack Current API call
    /// And bring the result to the screen
    /// </summary>
    /// <param name="placeName">General Parameter (Like City Name, County Name etc)</param>
    /// <param name="unit">Unit Parameter</param>
    /// <param name="language">Language Parameter (You shouldn't fill this parameter if your key is free version)</param>
    /// <returns>Current Weather Info</returns>
    [HttpPost]
    public async Task<CurrentWeather?> GetCurrentWeather(string placeName, string unit, string language)
    {
        try
        {
            var apiKey = _configuration.GetValue<string>("API_Key"); 
        
            var httpClient = new HttpClient();
            httpClient.Timeout = new TimeSpan(0, 0, 30);
        
            var requestString = "http://api.weatherstack.com/" + $"current?access_key={apiKey}&query={placeName}";
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

    /// <summary>
    /// This method is used to make WeatherStack Current API call
    /// And bring the result to the screen
    /// But in this method we use the whole model
    /// </summary>
    /// <param name="model">Current Weather Search Page Elements</param>
    /// <returns>Result Page</returns>
    [HttpPost]
    public async Task<IActionResult> GetCurrentWeatherWithModel(CurrentWeatherViewModel model)
    {
        if (!ModelState.IsValid) return View("IndexWithModel", model);
        var apiKey = _configuration.GetValue<string>("API_Key"); 
        
        var httpClient = new HttpClient();
        httpClient.Timeout = new TimeSpan(0, 0, 30);
        
        var requestString = "http://api.weatherstack.com/" + $"current?access_key={apiKey}&query={model.PlaceName}";
        if (!string.IsNullOrEmpty(model.Unit))
            requestString += $"&unit={model.Unit}";
        if (!string.IsNullOrEmpty(model.Language))
            requestString += $"&language={model.Language}";
        
        var response = await httpClient.GetAsync(requestString);
        var result = await response.Content.ReadAsStringAsync();

        var serializer = new DataContractJsonSerializer(typeof(CurrentWeather));
        var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(result));
        var currentWeather = (CurrentWeather)serializer.ReadObject(memoryStream)!;

        model = new CurrentWeatherViewModel
        {
            CurrentWeather = currentWeather
        };

        return View("IndexWithModel", model);

    }
}