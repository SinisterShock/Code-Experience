using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XSunriseSunset
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherForecast : ContentPage
    {
        public WeatherForecast()
        {
            InitializeComponent();
            
        }

        public async void ReadForcastAPI()
        {
            var lat = App.loc.latitude;
            var lng = App.loc.longtitude;
            var name = App.loc.name;

            using (HttpClient client = new HttpClient())
            {
                try
                {

                    var response2 = await client.GetAsync("https://api.openweathermap.org/data/2.5/weather?lat=" + lat + "&lng=" + lng + "&appid=c2dbe645b88e73bd3925966d5afb1ccc");
                    var json2 = await response2.Content.ReadAsStringAsync();

                    var results = JsonConvert.DeserializeObject<CurrentForcast>(json2);
                   
                    foreach(var day in results.daily)
                    {
                        DisplayWeather tempWeather = new DisplayWeather();
                        DateTime localDateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(day.dt).DateTime.ToLocalTime();
                        string dayOfWeek = localDateTimeOffset.DayOfWeek.ToString();

                        // bg color if statement

                       
                    }
                    



                }
                catch (Exception ex)
                {
                    _ = DisplayAlert("Error", "No response from API call. - " + ex.Message, "OK");
                }
            } // end using
        }// end ReadAPIAsync
    }
}
