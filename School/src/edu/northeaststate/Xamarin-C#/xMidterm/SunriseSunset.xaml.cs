using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace xMidterm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SunriseSunset : ContentPage
    {
        City myCity = App.city;
        /// <summary>
        /// Initializes the page and starts the Sun Api
        /// </summary>
        public SunriseSunset()
        {
            InitializeComponent();
            ReadSunApi();

        }

        /// <summary>
        /// Activates the Sunset Api
        /// </summary>
        private async void ReadSunApi()
        {
            string cityLat = System.Convert.ToString(myCity.lat);
            string cityLon = System.Convert.ToString(myCity.lon);

            string URI = "https://api.sunrise-sunset.org/json?lat=" + cityLat + "&lng=" + cityLon + "&date=today";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response2 = await client.GetAsync(URI);
                    var json2 = await response2.Content.ReadAsStringAsync();

                    var results1 = JsonConvert.DeserializeObject<Sunrise>(json2);

                    lblSunriseLocation.Text = myCity.name;

                    DateTime univDateTime = DateTime.Parse(results1.results.sunrise);
                    DateTime localDateTime = univDateTime.ToLocalTime();
                    lblSunrise.Text = "Sunrise: " + localDateTime;

                    univDateTime = DateTime.Parse(results1.results.sunset);
                    localDateTime = univDateTime.ToLocalTime();
                    lblSunset.Text = "Sunset: " + localDateTime;

                    univDateTime = DateTime.Parse(results1.results.civil_twilight_begin);
                    localDateTime = univDateTime.ToLocalTime();
                    lblTwilightBegin.Text = "Twilight Begin: " + localDateTime;

                    univDateTime = DateTime.Parse(results1.results.civil_twilight_end);
                    localDateTime = univDateTime.ToLocalTime();
                    lblTwilightEnd.Text = "Twilight End: " + localDateTime;

                    lblDayLength.Text = "Day Length: " + results1.results.day_length;

                }
                catch (Exception err)
                {
                    _ = DisplayAlert("Error", err.Message, "ok");
                }
            }


        }
        /// <summary>
        /// Deletes the location from the database and redirects to the main page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnDelete_Clicked(object sender, EventArgs e)
        {
            int rowsDeleted = 0;
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<City>();
                rowsDeleted = conn.Delete(myCity);
            }
            if (rowsDeleted > 0)
            {
                _ = DisplayAlert("Sucess", "Location successfully deleted from the database.", "OK");
            }
            else
            {
                _ = DisplayAlert("Error", "Location could not be found in the database.", "Ok");
            }
            Navigation.PopAsync();
        }
    }
}