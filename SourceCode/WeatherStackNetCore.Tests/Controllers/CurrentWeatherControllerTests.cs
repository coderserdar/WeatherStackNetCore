using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using WeatherStackNetCore.Controllers;
using WeatherStackNetCore.Models;

namespace WeatherStackNetCore.Tests.Controllers;

public class CurrentWeatherControllerTests
{
    private CurrentWeatherViewModel _model;
    private IConfiguration _config;
    private Mock _mock;
    private CurrentWeatherController _controller;

    [SetUp]
    public void Setup()
    {
        _model = new CurrentWeatherViewModel();
        _model.PlaceName = "Konya";
        _config = new ConfigurationManager();
        _controller = new CurrentWeatherController(_config);
    }

    [Test]
    public void IndexWithModel_Test()
    {
        var result = _controller.IndexWithModel(_model);
        Assert.IsNotNull(result);
    }
    
    [Test]
    public void GetCurrentWeatherWithModel_Test()
    {
        var result = _controller.GetCurrentWeatherWithModel(_model);
        Assert.IsNotNull(result);
    }
    
    [Test]
    public void IndexWithJQuery_Test()
    {
        var result = _controller.IndexWithJQuery();
        Assert.IsNotNull(result);
    }
    
    [Test]
    public void GetCurrentWeatherWithJQuery_Test()
    {
        var result = _controller.GetCurrentWeather(_model.PlaceName, _model.Unit, _model.Language);
        Assert.AreSame(result.Exception, null);
    }
}