using WebAPI_week1.Models;

namespace WebAPI_week1.DTOs
{
    public class WeatherDTO
    {
        public string? city_name { get; set; }
        public Datum[] data { get; set; }
        public string? state_code { get; set; }
        public string? country_code { get; set; }
        public string? timezone { get; set; }
        public float lon { get; set; }
        public float lat { get; set; }
    }
}
