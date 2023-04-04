using Microsoft.Extensions.Configuration;
using Moq;
using WeatherStackNetCore.Controllers;
using WeatherStackNetCore.Models;

namespace WeatherStackNetCore.Tests.Controllers;

/// <summary>
/// Test class for the controller
/// Which is used to get location info from the
/// WeatherStack API
/// </summary>
public class AutoCompleteControllerTests
{
    /// <summary>
    /// Location Info Model
    /// </summary>
    private AutoCompleteViewModel? _model;
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
    private AutoCompleteController? _controller;

    /// <summary>
    /// This method is used to create setup
    /// Assign values which are necessary
    /// Before using test methods
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _model = new AutoCompleteViewModel
        {
            PlaceName = "Ankara"
        };
        _config = new ConfigurationManager();
        _controller = new AutoCompleteController(_config);
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
    /// Get Location action with Model
    /// </summary>
    [Test]
    public void GetLocationsWithModel_Test()
    {
        var result = _controller?.GetLocationsWithModel(_model);
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
    /// Get Location action with JQuery
    /// </summary>
    [Test]
    public void GetLocationsWithJQuery_Test()
    {
        var result = _controller?.GetLocations(_model.PlaceName);
        Assert.AreSame(result.Exception, null);
    }
}