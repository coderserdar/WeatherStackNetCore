namespace WeatherStackNetCore.Utils;

/// <summary>
/// API Request Result Class
/// </summary>
public class AutoComplete
{
    public LocationRequest request { get; set; }
    public List<Location> results { get; set; }
    public string success { get; set; }
    public Error error { get; set; }
}