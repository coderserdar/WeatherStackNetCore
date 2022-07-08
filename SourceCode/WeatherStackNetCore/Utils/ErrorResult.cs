using System.Text.Json.Serialization;

namespace WeatherStackNetCore.Utils;

/// <summary>
/// Error Class
/// </summary>
public class ErrorResult
{
    public string success { get; set; }
    public Error error { get; set; }
}