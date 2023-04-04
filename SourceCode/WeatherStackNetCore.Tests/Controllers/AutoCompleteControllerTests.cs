using Microsoft.Extensions.Configuration;
using Moq;
using WeatherStackNetCore.Controllers;
using WeatherStackNetCore.Models;

namespace WeatherStackNetCore.Tests.Controllers;

public class AutoCompleteControllerTests
{
    private AutoCompleteViewModel? _model;
    private IConfiguration? _config;
    private Mock? _mock;
    private AutoCompleteController? _controller;

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

    [Test]
    public void IndexWithModel_Test()
    {
        var result = _controller?.IndexWithModel(_model);
        Assert.That(result, Is.Not.Null);
    }
    
    [Test]
    public void GetLocationsWithModel_Test()
    {
        var result = _controller?.GetLocationsWithModel(_model);
        Assert.That(result, Is.Not.Null);
    }
    
    [Test]
    public void IndexWithJQuery_Test()
    {
        var result = _controller?.IndexWithJQuery();
        Assert.That(result, Is.Not.Null);
    }
    
    [Test]
    public void GetLocationsWithJQuery_Test()
    {
        var result = _controller?.GetLocations(_model.PlaceName);
        Assert.AreSame(result.Exception, null);
    }
}