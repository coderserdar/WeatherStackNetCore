using System.Text.Json.Serialization;

namespace WeatherStackNetCore.Utils;

/// <summary>
/// Error Class
/// </summary>
public class Error
{
    public string type { get; set; }
    public string info { get; set; }
    public int code { get; set; }
}