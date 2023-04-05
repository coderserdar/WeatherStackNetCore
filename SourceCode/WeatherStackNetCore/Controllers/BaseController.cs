using Microsoft.AspNetCore.Mvc;

namespace WeatherStackNetCore.Controllers;

/// <summary>
/// This class is Base Controller class that
/// Some methods for all controllers have been added to this class
/// For recuding code lines etc.
/// </summary>
public class BaseController : Controller
{
    /// <summary>
    /// This method is used to set success message to ViewBag
    /// </summary>
    public void SetSuccessMessage()
    {
        ViewBag.MessageType = "success";
        ViewBag.BoxType = "normal";
        ViewBag.Message = "Operation is successful";
    }
    
    /// <summary>
    /// This method is used to set error message to ViewBag
    /// </summary>
    /// <param name="errorMessage">Specific Error Message</param>
    public void SetErrorMessage(string errorMessage)
    {
        ViewBag.MessageType = "error";
        ViewBag.BoxType = "large";
        ViewBag.Message = errorMessage;
    }
}