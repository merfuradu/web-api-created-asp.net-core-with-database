using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_week1.Models
{
    public class Datum
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Primary key
        public float? SnowDepth { get; set; }
        public float? Dni { get; set; }
        public string? WindCdir { get; set; }
        public float? Rh { get; set; }
        public string? Pod { get; set; }
        public float? Ozone { get; set; }
        public float? Pres { get; set; }
        public float? CloudsHi { get; set; }
        public float? Clouds { get; set; }
        public float? Vis { get; set; }
        public float? WindSpd { get; set; }
        public string? WindCdirFull { get; set; }
        public float? Slp { get; set; }
        public string? Datetime { get; set; }
        public float? Ts { get; set; }
        public float? Snow { get; set; }
        public float? Dewpt { get; set; }
        public float? Uv { get; set; }
        public float? WindDir { get; set; }
        public float? Ghi { get; set; }
        public float? Dhi { get; set; }
        public float? WindGustSpd { get; set; }
        public float? Temp { get; set; }
        public float? SolarRad { get; set; }
        public DateTime? TimestampUtc { get; set; }
        public float? Pop { get; set; }
        public float? AppTemp { get; set; }
        public float? CloudsLow { get; set; }
        public DateTime? TimestampLocal { get; set; }
        public float? CloudsMid { get; set; }
        public float? Precip { get; set; }

        // Foreign key for the Weather entity
        public int WeatherId { get; set; }
        public Weather Weather { get; set; } // Navigation property
    }
}
