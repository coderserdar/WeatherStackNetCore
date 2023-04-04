using System.ComponentModel.DataAnnotations;
using WeatherStackNetCore.Utils;

namespace WeatherStackNetCore.Models;

/// <summary>
/// This model class is used to create the search page
/// And stores the result info too
/// </summary>
public class AutoCompleteViewModel
{
    #region Fields

    [Required(ErrorMessage = "Please Enter A Place Name")]
    [Display(Name = "Place Name:")]
    public string? PlaceName { get; set; }
    
    public AutoComplete? AutoComplete { get; init; }

    #endregion
}