using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using static xFinal.Model.Tide;
/// <summary>
/// Name: Tyler Burleson
/// Date: 5/03/2022
/// Email: tburles6@stumail.northeaststate.edu
/// </summary>
namespace xFinal.ViewModel
{
    internal class TideViewModel 
    {
        /// <summary>
        /// Observable collection holding the data in the api call
        /// </summary>
        public ObservableCollection<DisplayPrediction> displayPredictions { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public TideViewModel()
        {
            displayPredictions = new ObservableCollection<DisplayPrediction>();
        }

        
        /// <summary>
        /// NOA Weather Api 
        /// </summary>
        public async void ReadAPIAsync()
        {
          

            //await DisplayAlert("Location", "You have a location", "Ok");
            using (HttpClient client = new HttpClient())
            {
                try
                {

                    //Current Date, API can only do one date at a time, not a range
                    DateTime now = DateTime.Now;
                    string date = now.ToString("yyyy-MM-dd");


                    var response2 = await client.GetAsync("https://api.tidesandcurrents.noaa.gov/api/prod/datagetter?station=8661070&time_zone=lst_ldt&units=english&product=predictions&range=120&begin_date=20220413&format=json&interval=hilo&product=water_temperature&application=Dave&datum=MLLW");
                    var json2 = await response2.Content.ReadAsStringAsync();

                    var results = JsonConvert.DeserializeObject<MyrtleBeachTides>(json2);

                    
                    foreach (var prediction in results.predictions)
                    {
                        DisplayPrediction prediction2 = new DisplayPrediction();
                        prediction2.DisplayValue = prediction.v;
                        prediction2.DisplayType = prediction.type;
                        prediction2.DisplayTime = prediction.t;

                        displayPredictions.Add(prediction2);
                    }
   
                }
                catch (Exception ex)
                {
                    _ = Application.Current.MainPage.DisplayAlert("Error", "No response from API call. - " + ex.Message, "OK");
                }
            } // end using
        }
    }
}
