using Moq;
using WeatherStackNetCore.Controllers;

namespace WeatherStackNetCore.Tests.Controllers;

/// <summary>
/// Test class for the controller
/// Which is used to get current weather info from the
/// WeatherStack API
/// </summary>
public class BaseControllerTests
{
    /// <summary>
    /// Mock class instance
    /// </summary>
    private Mock? _mock;
    /// <summary>
    /// Controller instance
    /// </summary>
    private BaseController _controller;

    /// <summary>
    /// This method is used to create setup
    /// Assign values which are necessary
    /// Before using test methods
    /// </summary>
    [SetUp]
    public void Setup()
    {
        _controller = new BaseController();
    }

    /// <summary>
    /// Test method which is used for
    /// Set Success Message for ViewBag
    /// </summary>
    [Test]
    public void SetSuccessMessage_Test()
    {
        try
        {
            _controller.SetSuccessMessage();
            Assert.IsTrue(true);
        }
        catch {
            Assert.IsTrue(false);
        }
    }
    
    /// <summary>
    /// Test method which is used for
    /// Set Error Message for ViewBag
    /// </summary>
    [Test]
    public void SetErrorMessage_Test()
    {
        try
        {
            _controller.SetErrorMessage("Test");
            Assert.IsTrue(true);
        }
        catch {
            Assert.IsTrue(false);
        }
    }
}