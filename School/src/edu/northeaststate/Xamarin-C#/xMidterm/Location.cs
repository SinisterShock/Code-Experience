using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace xMidterm
{/// <summary>
/// Sets up the languages to only English for city result names
/// </summary>
    public class LocalNames
    {
        public string en { get; set; }
    }
    /// <summary>
    /// Results for the Geo Weather Api 
    /// </summary>
    public class Location
    {
        public string name { get; set; }
        public LocalNames local_names { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public string country { get; set; }
        public string state { get; set; }
    }
    /// <summary>
    /// Database for the Geo Api to be stored
    /// </summary>

    public class City
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(20)]
        public string lat { get; set; }

        [MaxLength(20)]
        public string lon { get; set; }

        [MaxLength(100)]
        public string name { get; set; }

    }

}
