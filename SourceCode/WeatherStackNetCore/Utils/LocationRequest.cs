namespace WeatherStackNetCore.Utils;

/// <summary>
/// API Request Class
/// </summary>
public class LocationRequest
{
    public string query { get; set; }
    public int results { get; set; }
}