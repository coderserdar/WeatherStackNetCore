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

    [Display(Name = "Unit:")] public string? Unit { get; set; }

    [Display(Name = "Language:")] public string? Language { get; set; }

    /// <summary>
    /// This is used to fill dropdownlist for units
    /// </summary>
    public List<ItemList> UnitList { get; set; }

    /// <summary>
    /// This is used to fill dropdownlist for languages
    /// </summary>
    public List<ItemList> LanguageList { get; set; }

    /// <summary>
    /// API Call result
    /// </summary>
    public CurrentWeather? CurrentWeather { get; set; }

    #endregion

    public CurrentWeatherViewModel()
    {
        UnitList = new List<ItemList>();
        UnitList.Add(new ItemList {Text = "Metric", Value = "m"});
        UnitList.Add(new ItemList {Text = "Scientific", Value = "s"});
        UnitList.Add(new ItemList {Text = "Fahrenheit", Value = "f"});

        LanguageList = new List<ItemList>();
        LanguageList.Add(new ItemList {Text = "English", Value = "en"});
        LanguageList.Add(new ItemList {Text = "Turkish", Value = "tr"});
        LanguageList.Add(new ItemList {Text = "German", Value = "de"});
    }
}