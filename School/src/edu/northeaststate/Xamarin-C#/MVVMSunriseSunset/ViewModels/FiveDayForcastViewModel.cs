using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace XSunriseSunset.ViewModels
{
    /// <summary>
    /// Used to display the 5 day forcast
    /// </summary>
    internal class FiveDayForcastViewModel 
    {
       
        /// <summary>
        /// makes an observable collection for the displayed weather
        /// </summary>
        public ObservableCollection<DisplayWeather> displayWeather { get; set; }
        /// <summary>
        /// creates a new list/ constructor
        /// </summary>
        public FiveDayForcastViewModel()
        {
            displayWeather = new ObservableCollection<DisplayWeather>();
        }
       /// <summary>
       /// API for a weekly forcast
       /// </summary>
        public async void ReadAPIForcastWeatherDataAsync()
        {
            var lat = App.location.latitude;
            var lng = App.location.longtitude;
            //var name = myLoc.name;

            //await DisplayAlert("Location", "You have a location", "Ok");
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var response2 = await client.GetAsync("https://api.openweathermap.org/data/2.5/onecall?lat=" + App.location.latitude + "&lon=" + App.location.longtitude + "&units=imperial&exclude=hourly,minutely&appid=8e9baeddabe82b140620f12971f418ee");
                    var json2 = await response2.Content.ReadAsStringAsync();

                    var results = JsonConvert.DeserializeObject<Forcast>(json2);

                    

                    int cnt = 1;

                    foreach (var day in results.daily)
                    {
                        DisplayWeather tempWeather = new DisplayWeather();

                        DateTime localDateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(day.dt).DateTime.ToLocalTime();
                        string dayOfWeek = localDateTimeOffset.DayOfWeek.ToString();


                        if (cnt % 2 == 0)
                        {
                            tempWeather.bgColor = "AliceBlue";
                        }
                        else
                        {
                            tempWeather.bgColor = "Aquamarine";
                        }

                        tempWeather.localDateTimeOffset = dayOfWeek + " " + localDateTimeOffset.ToShortDateString();
                        tempWeather.min = "Low: " + day.temp.min;
                        tempWeather.max = "High: " + day.temp.max;
                        tempWeather.pressure = "hPa: " + day.pressure;
                        tempWeather.humidity = "Humidity: " + day.humidity;
                        tempWeather.windSpeed = "Wind: " + day.wind_speed;
                        tempWeather.windDirection = "Dir: " + day.wind_deg;
                        tempWeather.windGust = "Gust: " + day.wind_gust;
                        tempWeather.desc = day._weather[0].description;
                        displayWeather.Add(tempWeather);



                        cnt++;
                        
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
