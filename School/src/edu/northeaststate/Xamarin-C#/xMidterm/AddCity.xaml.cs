using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xMidterm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCity : ContentPage
    {
        public AddCity()
        {
            InitializeComponent();
        }
        /// <summary>
        /// sets the Picker for each state in the USA
        /// </summary>
    
        protected override void OnAppearing()
        {
            base.OnAppearing();
            List<string> states = new List<string>();
            states.Add("Alabama AL");
            states.Add("Alaska AK");
            states.Add("Arizona AZ");
            states.Add("Arkansas AR");
            states.Add("California CA");
            states.Add("Colorado CO");
            states.Add("Connecticut CT");
            states.Add("Delaware DE");
            states.Add("Florida FL");
            states.Add("Georgia GA");
            states.Add("Hawaii HI");
            states.Add("Idaho ID");
            states.Add("Illinois IL");
            states.Add("Indiana IN");
            states.Add("Iowa IA");
            states.Add("Kansas KS");
            states.Add("Kentucky KY");
            states.Add("Louisiana LA");
            states.Add("Maine ME");
            states.Add("Maryland MD");
            states.Add("Massachusetts MA");
            states.Add("Michigan MI");
            states.Add("Minnesota MN");
            states.Add("Mississippi MS");
            states.Add("Missouri MO");
            states.Add("New Jersey NJ");
            states.Add("Montana MT");
            states.Add("Nebraska NE");
            states.Add("Nevada NV");
            states.Add("New Hampshire NH");
            states.Add("New Mexico NM");
            states.Add("New York NY");
            states.Add("North Carolina NC");
            states.Add("North Dakota ND");
            states.Add("Ohio OH");
            states.Add("Oklahoma OK");
            states.Add("Oregon OR");
            states.Add("Pennsylvania PA");
            states.Add("Rhode Island RI");
            states.Add("South Carolina SC");
            states.Add("South Dakota SD");
            states.Add("Tennessee TN");
            states.Add("Texas TX");
            states.Add("Utah UT");
            states.Add("Vermont VT");
            states.Add("Virginia VA");
            states.Add("Washington WA");
            states.Add("West Virginia WV");
            states.Add("Wisconsin WI");
            states.Add("Wyoming WY");

            pkrState.ItemsSource = states;
        }
        /// <summary>
        /// When clicked use the user input to activate the ReadGeoApi
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        private void btnSubmit_Clicked(object sender, EventArgs e)
        {
            ReadGeoApi(efCityName.Text, pkrState.SelectedItem.ToString(), pkrCountry.SelectedItem.ToString());
           
          
        }
        /// <summary>
        /// Using the Geo Weather Api and user input it finds the latitude and longitude and uses the insert city method to add it to the database
        /// </summary>
        /// <param name="city"></param>
        /// <param name="country"></param>
        /// <param name="state"></param>
        private async void ReadGeoApi(string city, string state, string country)
        {
            string loc = city + "," + state + "," + country;
            string URI = "https://api.openweathermap.org/geo/1.0/direct?q=" + loc + "&limit=5&appid=c2dbe645b88e73bd3925966d5afb1ccc";

            using(HttpClient client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(URI);
                    var byteArray = await response.Content.ReadAsByteArrayAsync();

                    string json = System.Text.Encoding.Default.GetString(byteArray);

                    List<Location> locations =  JsonConvert.DeserializeObject<List<Location>>(json);

                    if(locations.Count > 0)
                    {
                        string lat = locations[0].lat.ToString();
                        string lon = locations[0].lon.ToString();
                        string name = locations[0].name;

                        InsertCity(lat, lon, name);
                    }
                    Console.WriteLine();   
                }
                catch (Exception err)
                {
                    _ = DisplayAlert("Error", err.Message, "ok");
                }
                
            }
        }
        /// <summary>
        /// Inserts the given city into the database
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="lat"></param>
        /// <param name="lon"></param>
        private void InsertCity(string lat, string lon, string cityName)
        {
            City city = new City(); //{ lat = lat, lon = lon, name = cityName };
            city.lat = lat;
            city.lon = lon;
            city.name = cityName;

            using(SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                //creates table
                conn.CreateTable<City>();

                int rowCount = conn.Insert(city);
                if(rowCount > 0)
                {
                    _ = DisplayAlert("Sucess", "Location successfully added.", "OK");
                }
                else
                {
                    _ = DisplayAlert("Error", "Location could not be added", "Ok");
                }
                conn.Close();
                Navigation.PopAsync();
            }
        }
    }
}