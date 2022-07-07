using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace XSunriseSunset.ViewModels
{
    internal class WeatherViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// instansiates the property changed
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// sets the name equal to the Name to be displayed
        /// </summary>
        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// sets the windgust equal to the Windgust to be displayed
        /// </summary>
        private string windGust;
        public string WindGust
        {
            get { return windGust; }
            set
            {
                windGust = value;
                OnPropertyChanged("WindGust");
            }
        }

        /// <summary>
        /// sets the windDegrees equal to the WindDegrees to be displayed
        /// </summary>
        private string windDegrees;
        public string WindDegrees
        {
            get { return windDegrees; }
            set
            {
                windDegrees = value;
                OnPropertyChanged("WindDegrees");
            }
        }

        /// <summary>
        /// sets the WindSpeed equal to the WindSpeed to be displayed
        /// </summary>
        private string windSpeed;
        public string WindSpeed
        {
            get { return windSpeed; }
            set
            {
                windSpeed = value;
                OnPropertyChanged("WindSpeed");
            }
        }
        /// <summary>
        /// sets the humidity equal to the humidity to be displayed
        /// </summary>
        private string humidity;
        public string Humidity
        {
            get { return humidity; }
            set
            {
                humidity = value;
                OnPropertyChanged("Humidity");
            }
        }

        /// <summary>
        /// sets the barometricPreasure equal to the barometric preasure to be displayed
        /// </summary>
        private string barometricPressure;
        public string BarometricPressure
        {
            get { return barometricPressure; }
            set
            {
                barometricPressure = value;
                OnPropertyChanged("BarometricPressure");
            }
        }

        /// <summary>
        /// sets the Temp min equal to the temp min to be displayed
        /// </summary>
        private string tempMin;
        public string TempMin
        {
            get { return tempMin; }
            set
            {
                tempMin = value;
                OnPropertyChanged("TempMin");
            }
        }

        /// <summary>
        /// sets the temp max equal to the temp max to be displayed
        /// </summary>
        private string tempMax;
        public string TempMax
        {
            get { return tempMax; }
            set
            {
                tempMax = value;
                OnPropertyChanged("TempMax");
            }
        }

        /// <summary>
        /// sets the feels like equal to the feels like to be displayed
        /// </summary>
        private string feelLike;
        public string FeelLike
        {
            get { return feelLike; }
            set
            {
                feelLike = value;
                OnPropertyChanged("FeelLike");
            }
        }

        /// <summary>
        /// sets the temp equal to the temp to be displayed
        /// </summary>
        private string temp;
        public string Temp
        {
            get { return temp; }
            set
            {
                temp = value;
                OnPropertyChanged("Temp");
            }
        }

        /// <summary>
        /// sets the desc equal to the desc to be displayed
        /// </summary>
        private string desc;
        public string Desc
        {
            get { return desc; }
            set
            {
                desc = value;
                OnPropertyChanged("Desc");
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
                    //DateTime now = DateTime.Now;
                    //string date = now.ToString("yyyy-MM-dd");

                    var response2 = await client.GetAsync("https://api.openweathermap.org/data/2.5/weather?units=imperial&lat=" + lat + "&lon=" + lng + "&appid=70a389759cde3cbd0e38bcf1792cbbcc");
                    var json2 = await response2.Content.ReadAsStringAsync();

                    var results = JsonConvert.DeserializeObject<CityWeather>(json2);

                    //string iconURL = "https://openweathermap.org/img/wn/";
                    //string weatherICON = results.weather[0].icon + ".png";
                    //string iconAddr = iconURL + weatherICON;
                    Name = results.name;
                    //ImageIcon.Source = iconAddr;
                    Desc = "Conditions: " + results.weather[0].description;
                    Temp = "Current Temperature " + results.main.temp.ToString();
                    FeelLike = "Feels Like: " + results.main.feels_like.ToString();
                    TempMax = "Maximum Temperature: " + results.main.temp_max.ToString();
                    TempMin = "Minimun Temperature: " + results.main.temp_min.ToString();
                    BarometricPressure = "Barometric Pressure: " + results.main.pressure.ToString();
                    Humidity = "Humidity: " + results.main.humidity.ToString();
                    WindSpeed = "Wind Speed: " + results.wind.speed.ToString();
                    WindDegrees = "Wind Direction (Degrees): " + results.wind.deg.ToString();
                    WindGust = "Wind Gusts: " + results.wind.gust.ToString();

                    // TODO - complete weather readout
                    // Icon Example: https://openweathermap.org/img/wn/01d.png

                }
                catch (Exception ex)
                {
                    _ = Application.Current.MainPage.DisplayAlert("Error", "No response from API call. - " + ex.Message, "OK");
                }
            } // end using
        }
    }
}
