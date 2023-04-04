using Microsoft.Extensions.Configuration;
using Moq;
using WeatherStackNetCore.Controllers;
using WeatherStackNetCore.Models;

namespace WeatherStackNetCore.Tests.Controllers;

/// <summary>
/// Test class for the controller
/// Which is used to get current weather info from the
/// WeatherStack API
/// </summary>
public class CurrentWeatherControllerTests
{
    /// <summary>
    /// Current Weather Info Model
    /// </summary>
    private CurrentWeatherViewModel? _model;
    /// <summary>
    /// Config file for controller constructor
    /// </summary>
    private IConfiguration? _config;
    /// <summary>
    /// Mock class instance
    /// </summary>
    private Mock? _mock;
    /// <summary>
    /// Controller instance
    /// </summary>
    private CurrentWeatherController? _controller;

    /// <summary>
    /// This method is used to create setup
    /// Assign values which are necessary
    /// Before using test methods
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _model = new CurrentWeatherViewModel
        {
            PlaceName = "Konya"
        };
        _config = new ConfigurationManager();
        _controller = new CurrentWeatherController(_config);
    }

    /// <summary>
    /// Test method which is used for
    /// Index action with model
    /// </summary>
    [Test]
    public void IndexWithModel_Test()
    {
        var result = _controller?.IndexWithModel(_model);
        Assert.That(result, Is.Not.Null);
    }
    
    /// <summary>
    /// Test method which is used for
    /// Get Current Weather Info action with Model
    /// </summary>
    [Test]
    public void GetCurrentWeatherWithModel_Test()
    {
        var result = _controller?.GetCurrentWeatherWithModel(_model);
        Assert.That(result, Is.Not.Null);
    }
    
    /// <summary>
    /// Test method which is used for
    /// Index action with JQuery
    /// </summary>
    [Test]
    public void IndexWithJQuery_Test()
    {
        var result = _controller?.IndexWithJQuery();
        Assert.That(result, Is.Not.Null);
    }
    
    /// <summary>
    /// Test method which is used for
    /// Get Current Weather Info action with JQuery
    /// </summary>
    [Test]
    public void GetCurrentWeatherWithJQuery_Test()
    {
        var result = _controller?.GetCurrentWeather(_model.PlaceName, _model.Unit, _model.Language);
        Assert.AreSame(result.Exception, null);
    }
}