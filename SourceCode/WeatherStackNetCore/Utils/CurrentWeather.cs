using System.Text.Json.Serialization;

namespace WeatherStackNetCore.Utils;

/// <summary>
/// API Request Result Class
/// </summary>
public class CurrentWeather
{
    public GeneralRequest request { get; set; }
    public Location location { get; set; }
    public Current current { get; set; }
    public string success { get; set; }
    public Error error { get; set; }
}