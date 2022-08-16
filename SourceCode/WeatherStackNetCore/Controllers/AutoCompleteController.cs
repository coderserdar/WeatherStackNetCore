using System.Runtime.Serialization.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using WeatherStackNetCore.Models;
using WeatherStackNetCore.Utils;

namespace WeatherStackNetCore.Controllers;

public class AutoCompleteController : Controller
{
    /// <summary>
    /// Config element
    /// </summary>
    private readonly IConfiguration configuration;

    /// <summary>
    /// This is the constructor of controller
    /// </summary>
    /// <param name="config"></param>
    public AutoCompleteController(IConfiguration config)
    {
        // this is used to get some key values from appSettings.Json
        configuration = config;
    }
    
    /// <summary>
    /// This is used to show Location search page
    /// </summary>
    /// <returns>Location search page</returns>
    public IActionResult IndexWithJQuery()
    {
        var model = new AutoCompleteViewModel();
        return View(model);
    }
    
    /// <summary>
    /// This is used to show Location search page
    /// </summary>
    /// <returns>Location search page</returns>
    public IActionResult IndexWithModel(AutoCompleteViewModel? model)
    {
        return View(model);
    }

    /// <summary>
    /// This method is used to make WeatherStack Current API call
    /// And bring the result to the screen
    /// </summary>
    /// <param name="placeName">General Parameter (Like City Name, County Name etc)</param>
    /// <returns>Location Info</returns>
    [HttpPost]
    public async Task<AutoComplete?> GetLocations(string placeName)
    {
        try
        {
            var apiKey = configuration.GetValue<string>("API_Key"); 
        
            var httpClient = new HttpClient();
            httpClient.Timeout = new TimeSpan(0, 0, 30);
        
            var requestString = "http://api.weatherstack.com/" + $"autocomplete?access_key={apiKey}&query={placeName}";
       
            var response = await httpClient.GetAsync(requestString);
            var result = await response.Content.ReadAsStringAsync();

            var serializer = new DataContractJsonSerializer(typeof(AutoComplete));
            var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var autoComplete = (AutoComplete)serializer.ReadObject(memoryStream)!;

            return autoComplete;
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
    /// <param name="model">Location Search Page Elements</param>
    /// <returns>Result Page</returns>
    [HttpPost]
    public async Task<IActionResult> GetLocationsWithModel(AutoCompleteViewModel model)
    {
        if (ModelState.IsValid)
        {
            var autoComplete = new AutoComplete();
        
            var apiKey = configuration.GetValue<string>("API_Key"); 
        
            var httpClient = new HttpClient();
            httpClient.Timeout = new TimeSpan(0, 0, 30);
        
            var requestString = "http://api.weatherstack.com/" + $"autocomplete?access_key={apiKey}&query={model.PlaceName}";
        
            var response = await httpClient.GetAsync(requestString);
            var result = await response.Content.ReadAsStringAsync();

            var serializer = new DataContractJsonSerializer(typeof(AutoComplete));
            var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(result));
            autoComplete = (AutoComplete)serializer.ReadObject(memoryStream)!;

            model = new AutoCompleteViewModel();
            model.AutoComplete = autoComplete;

            return View("IndexWithModel", model);
        }
        else
        {
            return View("IndexWithModel", model);
        }
    }
}