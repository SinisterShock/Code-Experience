using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace XSunriseSunset.ViewModels
{
    internal class AddCityViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// creates a success flag
        /// </summary>
        private bool success = false;
        /// <summary>
        /// submit command
        /// </summary>
        public Command SubmitCommand { get; set; }
        /// <summary>
        /// collection of states to be displayed
        /// </summary>
        public ObservableCollection<string> States { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// gets the city name
        /// </summary>
        public string CityName { get; set; }
  

        private string state;
        /// <summary>
        /// constructor
        /// </summary>
        public AddCityViewModel()
        {
            SubmitCommand = new Command(Submit);
            States = new ObservableCollection<string>();
        }
        /// <summary>
        /// sets the state that is selected
        /// </summary>
        public string State
        {
            get { return state; }
            set
            {
                state = value;
                OnPropertyChanged("State");
            }
        }
        /// <summary>
        /// sets the country that is selected
        /// </summary>
        private string country;
        public string Country
        {
            get { return country; }
            set
            {
                country = value;
                OnPropertyChanged("Country");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// adds the states to the collection
        /// </summary>
        public void OnAppearing()
        {
            
            States.Add("Alabama AL");
            States.Add("Alaska AK");
            States.Add("Arizona AZ");
            States.Add("Arkansas AR");
            States.Add("California CA");
            States.Add("Colorado CO");
            States.Add("Connecticut CT");
            States.Add("Delaware DE");
            States.Add("Florida FL");
            States.Add("Georgia GA");
            States.Add("Hawaii HI");
            States.Add("Idaho ID");
            States.Add("Illinois IL");
            States.Add("Indiana IN");
            States.Add("Iowa IA");
            States.Add("Kansas KS");
            States.Add("Kentucky KY");
            States.Add("Louisiana LA");
            States.Add("Maine ME");
            States.Add("Maryland MD");
            States.Add("Massachusetts MA");
            States.Add("Michigan MI");
            States.Add("Minnesota MN");
            States.Add("Mississippi MS");
            States.Add("Missouri MO");
            States.Add("New Jersey NJ");
            States.Add("Montana MT");
            States.Add("Nebraska NE");
            States.Add("Nevada NV");
            States.Add("New Hampshire NH");
            States.Add("New Mexico NM");
            States.Add("New York NY");
            States.Add("North Carolina NC");
            States.Add("North Dakota ND");
            States.Add("Ohio OH");
            States.Add("Oklahoma OK");
            States.Add("Oregon OR");
            States.Add("Pennsylvania PA");
            States.Add("Rhode Island RI");
            States.Add("South Carolina SC");
            States.Add("South Dakota SD");
            States.Add("Tennessee TN");
            States.Add("Texas TX");
            States.Add("Utah UT");
            States.Add("Vermont VT");
            States.Add("Virginia VA");
            States.Add("Washington WA");
            States.Add("West Virginia WV");
            States.Add("Wisconsin WI");
            States.Add("Wyoming WY");

            
        }
        /// <summary>
        /// submits the location selected 
        /// </summary>
        public void Submit()
        {
            ReadGEOAPIAsync(CityName, State, Country);

            if (success)
            {
                Application.Current.MainPage.Navigation.PopAsync();
            }

        }
        /// <summary>
        /// reads the api
        /// </summary>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="country"></param>
        public async void ReadGEOAPIAsync(string city, string state, string country)
        {
            string twoCharState = state.Substring(state.Length - 2);
            string twoCharCountry = country.Substring(country.Length - 2);

            //await DisplayAlert("Location", "You have a location", "Ok");
            using (HttpClient client = new HttpClient())
            {
                string restAPI = $"https://api.openweathermap.org/geo/1.0/direct?q=" + city + "," + twoCharState + "," + twoCharCountry + "&limit=5&appid=8e9baeddabe82b140620f12971f418ee";

                var response2 = await client.GetAsync(restAPI);
                string json2 = await response2.Content.ReadAsStringAsync();

                try
                {
                    if (String.IsNullOrEmpty(CityName))
                    {
                        _ = Application.Current.MainPage.DisplayAlert("You must enter a city", "warning", "OK");
                        success = false;
                    }
                    else
                    {
                        List<CityLocation> results = JsonConvert.DeserializeObject<List<CityLocation>>(json2);

                        if (results.Count > 0)
                        {
                            //found city
                            var cityName = results[0].name;
                            var stateName = results[0].state;
                            var lon = results[0].lon;
                            var lat = results[0].lat;

                            Location location = new Location();
                            location.state = stateName;
                            location.name = cityName;
                            location.latitude = lat.ToString();
                            location.longtitude = lon.ToString();
                            location.country = stateName;
                            location.stationID = "TBA";

                            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);
                            conn.CreateTable<Location>(); //create if it doesn't exist
                            int rowCount = conn.Insert(location);
                            conn.Close();

                            if (rowCount > 0)
                                success = true;
                            else
                                success = false;

                            if (success)
                            {
                                _ = Application.Current.MainPage.DisplayAlert("New city added to SQLite", "Success", "OK");
                                _ = Application.Current.MainPage.Navigation.PopAsync();
                            }
                            else
                                _ = Application.Current.MainPage.DisplayAlert("Could not add new location", "Error", "OK");


                        }
                        else
                        {
                            //city not found
                            _ = Application.Current.MainPage.DisplayAlert("City not found.", "Warning", "OK");
                            success = false;

                        }
                    }

                }
                catch (Exception ex)
                {
                    _ = Application.Current.MainPage.DisplayAlert(ex.Message, "Could not connect to API", "OK");
                }

                //=============================================================





            } // end using
        }
    }
}
