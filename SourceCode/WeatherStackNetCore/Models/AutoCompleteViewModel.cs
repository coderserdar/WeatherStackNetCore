using System.ComponentModel.DataAnnotations;
using WeatherStackNetCore.Utils;

namespace WeatherStackNetCore.Models;

public class AutoCompleteViewModel
{
    #region Fields

    [Required(ErrorMessage = "Please Enter A Place Name")]
    [Display(Name = "Place Name:")]
    public string? PlaceName { get; set; }
    
    public AutoComplete? AutoComplete { get; set; }

    #endregion
}