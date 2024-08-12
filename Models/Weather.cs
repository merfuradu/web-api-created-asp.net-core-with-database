namespace WebAPI_week1.Models
{
    public class Weather
    {

        public class Rootobject
        {
            public string city_name { get; set; }
            public Datum[] data { get; set; }
            public string state_code { get; set; }
            public string country_code { get; set; }
            public string timezone { get; set; }
            public int lon { get; set; }
            public float lat { get; set; }
        }

        public class Datum
        {
            public int snow_depth { get; set; }
            public int dni { get; set; }
            public string wind_cdir { get; set; }
            public int rh { get; set; }
            public string pod { get; set; }
            public int ozone { get; set; }
            public int pres { get; set; }
            public int clouds_hi { get; set; }
            public int clouds { get; set; }
            public float vis { get; set; }
            public float wind_spd { get; set; }
            public string wind_cdir_full { get; set; }
            public int slp { get; set; }
            public string datetime { get; set; }
            public int ts { get; set; }
            public int snow { get; set; }
            public float dewpt { get; set; }
            public int uv { get; set; }
            public int wind_dir { get; set; }
            public int ghi { get; set; }
            public int dhi { get; set; }
            public float wind_gust_spd { get; set; }
            public Weather weather { get; set; }
            public float temp { get; set; }
            public float solar_rad { get; set; }
            public DateTime timestamp_utc { get; set; }
            public int pop { get; set; }
            public float app_temp { get; set; }
            public int clouds_low { get; set; }
            public DateTime timestamp_local { get; set; }
            public int clouds_mid { get; set; }
            public int precip { get; set; }
        }

    }
}
