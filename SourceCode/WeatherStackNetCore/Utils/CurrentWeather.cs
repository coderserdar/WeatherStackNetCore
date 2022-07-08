using System.Text.Json.Serialization;

namespace WeatherStackNetCore.Utils;

/// <summary>
/// API Request Class
/// </summary>
public class Request
{
    public string type { get; set; }
    public string query { get; set; }
    public string language { get; set; }
    public string unit { get; set; }
}

/// <summary>
/// Query Place Detailed Location Info Class
/// </summary>
public class Location
{
    public string name { get; set; }
    public string country { get; set; }
    public string region { get; set; }
    public string lat { get; set; }
    public string lon { get; set; }
    public string timezone_id { get; set; }
    public string localtime { get; set; }
    public decimal localtime_epoch { get; set; }
    public string utc_offset { get; set; }
}

/// <summary>
/// Query Place Current Weather Information Class
/// </summary>
public class Current
{
    public string observation_time { get; set; }
    public decimal temperature { get; set; }
    public decimal weather_code { get; set; }
    public List<string> weather_icons { get; set; }
    public List<string> weather_descriptions { get; set; }
    public decimal wind_speed { get; set; }
    public decimal wind_degree { get; set; }
    public string wind_dir { get; set; }
    public decimal pressure { get; set; }
    public decimal precip { get; set; }
    public decimal humidity { get; set; }
    public decimal cloudcover { get; set; }
    public decimal feelslike { get; set; }
    public decimal uv_index { get; set; }
    public decimal visibility { get; set; }
}

/// <summary>
/// API Request Result Class
/// </summary>
public class CurrentWeather
{
    public Request request { get; set; }
    public Location location { get; set; }
    public Current current { get; set; }
}