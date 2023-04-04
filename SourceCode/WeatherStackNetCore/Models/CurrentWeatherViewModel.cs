using System.ComponentModel.DataAnnotations;
using WeatherStackNetCore.Utils;

namespace WeatherStackNetCore.Models;

/// <summary>
/// This model class is used to create the search page
/// And stores the result info too
/// </summary>
public class CurrentWeatherViewModel
{
    #region Fields

    [StringLength(60, MinimumLength = 3)]
    [Required(ErrorMessage = "Please Enter A Place Name")]
    [Display(Name = "Place Name:")]
    public string? PlaceName { get; set; }

    [Display(Name = "Unit:")] public string? Unit { get; init; }

    [Display(Name = "Language:")] public string? Language { get; init; }

    /// <summary>
    /// This is used to fill dropdownlist for units
    /// </summary>
    public List<ItemList> UnitList { get; init; }

    /// <summary>
    /// This is used to fill dropdownlist for languages
    /// </summary>
    public List<ItemList> LanguageList { get; init; }

    /// <summary>
    /// API Call result
    /// </summary>
    public CurrentWeather? CurrentWeather { get; init; }

    #endregion

    public CurrentWeatherViewModel()
    {
        UnitList = new List<ItemList>
        {
            new() {Text = "Metric", Value = "m"},
            new() {Text = "Scientific", Value = "s"},
            new() {Text = "Fahrenheit", Value = "f"}
        };

        LanguageList = new List<ItemList>
        {
            new() {Text = "English", Value = "en"},
            new() {Text = "Turkish", Value = "tr"},
            new() {Text = "German", Value = "de"}
        };
    }
}