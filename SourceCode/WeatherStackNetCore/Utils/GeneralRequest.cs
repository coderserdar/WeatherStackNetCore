using System.Text.Json.Serialization;

namespace WeatherStackNetCore.Utils;

/// <summary>
/// API Request Class
/// </summary>
public class GeneralRequest
{
    public string type { get; set; }
    public string query { get; set; }
    public string language { get; set; }
    public string unit { get; set; }
}