using System.Text.Json.Serialization;

namespace WeatherStackNetCore.Utils;

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