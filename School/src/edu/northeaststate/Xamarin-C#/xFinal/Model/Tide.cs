using System;
using System.Collections.Generic;
using System.Text;

namespace xFinal.Model
{
    internal class Tide
    {/// <summary>
    /// get and set for the time, value, and either low tide or high tide in the I list
    /// </summary>
        public class Prediction
        {
            public string t { get; set; }
            public string v { get; set; }
            public string type { get; set; }
        }
        /// <summary>
        /// I list used to call each value for 5 days
        /// </summary>
        public class MyrtleBeachTides
        {
        
            public IList<Prediction> predictions { get; set; }
        }

        /// <summary>
        /// used to store data from the IList to be displayed to the screen
        /// </summary>
        public class DisplayPrediction
        {
            public string DisplayTime { get; set; }
            public string DisplayType { get; set; }
            public string DisplayValue { get; set; }

        }

        

    }
}
