using System.Runtime.Serialization.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using WeatherStackNetCore.Models;
using WeatherStackNetCore.Utils;

namespace WeatherStackNetCore.Controllers;

/// <summary>
/// This controller is used to
/// Call API function which is about location searching
/// </summary>
public class AutoCompleteController : Controller
{
    /// <summary>
    /// Config element
    /// </summary>
    private readonly IConfiguration _configuration;

    /// <summary>
    /// This is the constructor of controller
    /// </summary>
    /// <param name="config"></param>
    public AutoCompleteController(IConfiguration config)
    {
        // this is used to get some key values from appSettings.Json
        _configuration = config;
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
        model ??= new AutoCompleteViewModel();
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
            var autoComplete = await CallAutoCompleteFromAPI(placeName);
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
    [ValidateModel]
    public async Task<IActionResult> GetLocationsWithModel(AutoCompleteViewModel model)
    {
        try
        {
            // if (!ModelState.IsValid) return View("IndexWithModel", model);
            
            var autoComplete = await CallAutoCompleteFromAPI(model.PlaceName);

            model = new AutoCompleteViewModel
            {
                AutoComplete = autoComplete
            };
            
            if (model.AutoComplete.error != null)
                SetErrorMessage(model.AutoComplete.error.info);
            else
                SetSuccessMessage();
            
            return View("IndexWithModel", model);
        }
        catch (Exception e)
        {
            model = new AutoCompleteViewModel
            {
                AutoComplete = null
            };

            SetErrorMessage("Something has gone wrong");

            return View("IndexWithModel", model);
        }
    }

    /// <summary>
    /// This method is used to set success message to ViewBag
    /// </summary>
    private void SetSuccessMessage()
    {
        ViewBag.MessageType = "success";
        ViewBag.BoxType = "normal";
        ViewBag.Message = "Operation is successful";
    }
    
    /// <summary>
    /// This method is used to set error message to ViewBag
    /// </summary>
    /// <param name="errorMessage">Specific Error Message</param>
    private void SetErrorMessage(string errorMessage)
    {
        ViewBag.MessageType = "error";
        ViewBag.BoxType = "large";
        ViewBag.Message = errorMessage;
    }

    /// <summary>
    /// This method is used to call WeatherStack API with place name
    /// And get the city info
    /// </summary>
    /// <param name="placeName">Place Name</param>
    /// <returns>Auto Complete Data (City etc. Data)</returns>
    private async Task<AutoComplete> CallAutoCompleteFromAPI(string? placeName)
    {
        var apiKey = _configuration.GetValue<string>("API_Key");

        var httpClient = new HttpClient();
        httpClient.Timeout = new TimeSpan(0, 0, 30);

        var requestString = "http://api.weatherstack.com/" + $"autocomplete?access_key={apiKey}&query={placeName}";

        var response = await httpClient.GetAsync(requestString);
        var result = await response.Content.ReadAsStringAsync();

        var serializer = new DataContractJsonSerializer(typeof(AutoComplete));
        var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(result));
        var autoComplete = (AutoComplete) serializer.ReadObject(memoryStream)!;
        return autoComplete;
    }
}