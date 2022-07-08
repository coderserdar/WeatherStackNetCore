using System.ComponentModel.DataAnnotations;
using WeatherStackNetCore.Utils;

namespace WeatherStackNetCore.Models;

public class CurrentWeatherViewModel
{
    #region Fields

    [Required(ErrorMessage = "Please Enter A Place Name")]
    [Display(Name = "Place Name:")]
    public string PlaceName { get; set; }

    [Display(Name = "Unit:")] public string Unit { get; set; }

    [Display(Name = "Language:")] public string Language { get; set; }

    public List<ItemList> UnitList { get; set; }

    public List<ItemList> LanguageList { get; set; }

    #endregion

    public CurrentWeatherViewModel()
    {
        UnitList = new List<ItemList>();
        UnitList.Add(new ItemList {Text = "Metric", Value = "m"});
        UnitList.Add(new ItemList {Text = "Scientific", Value = "s"});
        UnitList.Add(new ItemList {Text = "Fahrenheit", Value = "f"});

        LanguageList = new List<ItemList>();
        LanguageList.Add(new ItemList {Text = "Turkish", Value = "tr"});
        LanguageList.Add(new ItemList {Text = "German", Value = "de"});
    }
}