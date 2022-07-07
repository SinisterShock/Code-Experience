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
    public partial class CurrentConditions : ContentPage
    {
        public CurrentConditions()
        {
            InitializeComponent();
            ReadConditionAPI();
        }

        public async void ReadConditionAPI() {
            var lat = App.loc.latitude;
            var lng = App.loc.longtitude;
            var name = App.loc.name;

            using (HttpClient client = new HttpClient())
            {
                try
                {

                    var response2 = await client.GetAsync("https://api.openweathermap.org/data/2.5/weather?lat=" + lat + "&lng=" + lng + "&appid=c2dbe645b88e73bd3925966d5afb1ccc");
                    var json2 = await response2.Content.ReadAsStringAsync();

                    var results = JsonConvert.DeserializeObject<CurrentCondition>(json2);
                    

                    lblLocation.Text = name;
                    lblCondition.Text = results.weather[0].description;
                    lblCurrentTemperature.Text = results.main.temp.ToString();
                    lblFeelsLike.Text = results.main.feels_like.ToString();
                    lblMaxTemp.Text = results.main.temp_max.ToString();
                    lblMinTemp.Text = results.main.temp_min.ToString();
                    lblBarometric.Text = results.main.pressure.ToString();
                    lblHumidity.Text = results.main.humidity.ToString();
                    lblWindSpeed.Text = results.wind.speed.ToString();
                    lblWindGusts.Text = results.wind.gust.ToString();
                    lblWindDirections.Text = results.wind.deg.ToString();
                    


                }
                catch (Exception ex)
                {
                    _ = DisplayAlert("Error", "No response from API call from Current Conditions. - " + ex.Message, "OK");
                }
            } // end using
        }// end ReadAPIAsync
    }

}