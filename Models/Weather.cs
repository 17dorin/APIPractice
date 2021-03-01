using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPractice.Models
{

    public class Weather
    {
        public Context context { get; set; }
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }

    public class Context
    {
        public string version { get; set; }
    }

    public class Geometry
    {
        public string type { get; set; }
        public float[][][][] coordinates { get; set; }
    }

    public class Properties
    {
        public string zone { get; set; }
        public DateTime updated { get; set; }
        public Period[] periods { get; set; }
    }

    public class Period
    {
        public int number { get; set; }
        public string name { get; set; }
        public string detailedForecast { get; set; }
    }

}
