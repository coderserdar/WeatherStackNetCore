using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WeatherStackNetCore.Utils;

/// <summary>
/// Model Validation Attribute Class
/// </summary>
public class ValidateModelAttribute : ActionFilterAttribute
{
    /// <summary>
    /// In this method, if model is not valid
    /// App sends automatically bad request
    /// </summary>
    /// <param name="context">Context Info</param>
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
            context.Result = new BadRequestResult();
    }
}