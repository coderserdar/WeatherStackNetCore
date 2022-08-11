namespace WeatherStackNetCore.Utils;

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