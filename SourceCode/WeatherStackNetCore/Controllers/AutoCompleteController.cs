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
    private IConfiguration configuration;

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
    public IActionResult Index()
    {
        var model = new AutoCompleteViewModel();
        return View(model);
    }

    /// <summary>
    /// This method is used to make WeaherStack Current API call
    /// And bring the result to the screen
    /// </summary>
    /// <param name="query">General Parameter (Like City Name, County Name etc)</param>
    /// <returns>Location Info</returns>
    [HttpPost]
    public async Task<AutoComplete?> GetLocations(string query)
    {
        try
        {
            var apiKey = configuration.GetValue<string>("API_Key"); 
        
            var httpClient = new HttpClient();
            httpClient.Timeout = new TimeSpan(0, 0, 30);
        
            var requestString = "http://api.weatherstack.com/" + $"autocomplete?access_key={apiKey}&query={query}";
       
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
}