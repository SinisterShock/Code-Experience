using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace XSunriseSunset.ViewModels
{
    internal class SunriseSunsetViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// instansiates the property changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// constructor
        /// </summary>
        public SunriseSunsetViewModel()
        {
            DeleteCityCommand = new Command(DeleteCity);
        }
        /// <summary>
        /// command to delete the selected city
        /// </summary>
        public Command DeleteCityCommand { get; set; }

        /// <summary>
        /// sets the sunrisedatetime equal to the sunrisedatetime to be displayed
        /// </summary>
        private string sunriseDateTime;
        public string SunriseDateTime
        {
            get { return sunriseDateTime; }
            set
            {
                sunriseDateTime = value;
                OnPropertyChanged("SunriseDateTime");
            }
        }

        /// <summary>
        /// sets the sunriseLocation equal to the sunriseLocation to be displayed
        /// </summary>
        private string sunriseLocation;
        public string SunriseLocation
        {
            get { return sunriseLocation; }
            set
            {
                sunriseLocation = value;
                OnPropertyChanged("SunriseLocation");
            }
        }

        /// <summary>
        /// sets the sunsetDateTime equal to the sunsetDateTime to be displayed
        /// </summary>
        private string sunsetDateTime;
        public string SunsetDateTime
        {
            get { return sunsetDateTime; }
            set
            {
                sunsetDateTime = value;
                OnPropertyChanged("SunsetDateTime");
            }
        }

        /// <summary>
        /// sets the dayLength equal to the dayLength to be displayed
        /// </summary>
        private string dayLength;
        public string DayLength
        {
            get { return dayLength; }
            set
            {
                dayLength = value;
                OnPropertyChanged("DayLength");
            }
        }

        /// <summary>
        /// sets the twilightStart equal to the twilightStart to be displayed
        /// </summary>
        private string twilightStart;
        public string TwilightStart
        {
            get { return twilightStart; }
            set
            {
                twilightStart = value;
                OnPropertyChanged("TwilightStart");
            }
        }

        /// <summary>
        /// sets the twilightEnd equal to the twilightEnd to be displayed
        /// </summary>
        private string twilightEnd;
        public string TwilightEnd
        {
            get { return twilightEnd; }
            set
            {
                twilightEnd = value;
                OnPropertyChanged("TwilightEnd");
            }
        }
        /// <summary>
        /// creates an invoked method
        /// </summary>
        /// <param name="propertyName"></param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// deletes the selected city from the list 
        /// </summary>
        public void DeleteCity()
        {
            int rowsDeleted = 0;
            //delete database item
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Location>(); //create if it doesn't exist                
                rowsDeleted = conn.Delete(App.location);
            }
            
            if (rowsDeleted > 0)
                _ = Application.Current.MainPage.DisplayAlert("Success", "Location successfully deleted from the database.", "OK");
            else
                _ = Application.Current.MainPage.DisplayAlert("Error", "Location could not be found in the database.", "OK");

            App.Current.MainPage.Navigation.PopAsync();
        }

        /// <summary>
        /// reads the weather api
        /// </summary>
        public async void ReadAPIAsync()
        {
            var lat = App.location.latitude;
            var lng = App.location.longtitude;
            //var name = myLoc.name;

            //await DisplayAlert("Location", "You have a location", "Ok");
            using (HttpClient client = new HttpClient())
            {
                try
                {

                    //Current Date, API can only do one date at a time, not a range
                    DateTime now = DateTime.Now;
                    string date = now.ToString("yyyy-MM-dd");


                    var response2 = await client.GetAsync("https://api.sunrise-sunset.org/json?lat=" + lat + "&lng=" + lng + "=" + date);
                    var json2 = await response2.Content.ReadAsStringAsync();

                    var results = JsonConvert.DeserializeObject<Sunrises>(json2);

                    SunriseLocation = App.location.name;

                    DateTime univDateTime = DateTime.Parse(results.results.sunrise);
                    DateTime localDateTime = univDateTime.ToLocalTime();
                    SunriseDateTime = "Sunrise: " + localDateTime;

                    univDateTime = DateTime.Parse(results.results.sunset);
                    localDateTime = univDateTime.ToLocalTime();
                    SunsetDateTime = "Sunset: " + localDateTime;

                    DayLength = "Day Length: " + results.results.day_length;

                    univDateTime = DateTime.Parse(results.results.civil_twilight_begin);
                    localDateTime = univDateTime.ToLocalTime();
                    TwilightStart = "Twilight Begins: " + localDateTime;

                    univDateTime = DateTime.Parse(results.results.civil_twilight_end);
                    localDateTime = univDateTime.ToLocalTime();
                    TwilightEnd = "Twilight Ends: " + localDateTime;
                }
                catch (Exception ex)
                {
                    _ = Application.Current.MainPage.DisplayAlert("Error", "No response from API call. - " + ex.Message, "OK");
                }
            } // end using
        }
    }
}
