using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace xMidterm
{
    /// <summary>
    /// Results from the SunsetSunrise Api
    /// </summary>
    public class Results
    {
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public string solar_noon { get; set; }
        public string day_length { get; set; }
        public string civil_twilight_begin { get; set; }
        public string civil_twilight_end { get; set; }
        public string nautical_twilight_begin { get; set; }
        public string nautical_twilight_end { get; set; }
        public string astronomical_twilight_begin { get; set; }
        public string astronomical_twilight_end { get; set; }
    }
    /// <summary>
    /// Used to call the results and that a connection has been established
    /// </summary>
    public class Sunrise
    {
        public Results results { get; set; }
        public string status { get; set; }
    }
}
