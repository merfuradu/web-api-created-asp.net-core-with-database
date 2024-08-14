using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_week1.Models
{
    public class Datum
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Primary key
        public string? pod { get; set; }
        public float? pres { get; set; }
        public float? clouds { get; set; }
        public float? vis { get; set; }
        public float? wind_spd { get; set; }
        public string? wind_cdir_full { get; set; }
        public float? slp { get; set; }
        public string? datetime { get; set; }
        public float? ts { get; set; }
        public float? dewpt { get; set; }
        public float? uv { get; set; }
        public float? dni { get; set; }
        public DateTime? timestamp_utc { get; set; }
        public float? ghi { get; set; }
        public float? dhi { get; set; }
        public DateTime? timestamp_local { get; set; }
        public float? temp { get; set; }
        public float? app_temp { get; set; }
        public float? snow { get; set; }
        public float? solar_rad { get; set; }
        public float? pop { get; set; }
        public float? ozone { get; set; }
        public float? clouds_hi { get; set; }
        public float? clouds_low { get; set; }
        public float? clouds_mid { get; set; }
        public string? wind_cdir { get; set; }
        public float? wind_dir { get; set; }
        public float? precip { get; set; }
        public float? wind_gust_spd { get; set; }
        public float? snow_depth { get; set; }
        public float? rh { get; set; }

        // Foreign key for the Weather entity
        public int WeatherId { get; set; }
        public Weather Weather { get; set; } // Navigation property
    }
}
