using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_week1.Models
{
    public class Weather
    {
        [Key]
        public int Id { get; set; } // Primary key
        public string? city_name { get; set; }
        public string? state_code { get; set; }
        public string? country_code { get; set; }
        public string? timezone { get; set; }
        public float lon { get; set; }
        public float lat { get; set; }

        // Navigation property for the related data points
        public ICollection<Datum> DataPoints { get; set; } = new List<Datum>();
    }

}
