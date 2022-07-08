using System.Text.Json.Serialization;

namespace WeatherStackNetCore.Utils;

/// <summary>
/// API Request Result Class
/// </summary>
public class AutoComplete
{
    public LocationRequest request { get; set; }
    public List<Location> results { get; set; }
}