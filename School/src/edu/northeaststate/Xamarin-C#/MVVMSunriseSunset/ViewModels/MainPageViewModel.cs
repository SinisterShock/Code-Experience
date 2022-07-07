using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

/// <summary>
/// Name: Tyler Burleson
/// Date: 4/25/2022
/// Email: tburles6@stumail.northeaststate.edu
/// Note: IT FINALLY WORKS!!!!
/// </summary>
namespace XSunriseSunset.ViewModels
{
    internal class MainPageViewModel
    {
        /// <summary>
        /// takes the user to the add city page
        /// </summary>
        public Command AddCityClickedCommand { get; set; }
        /// <summary>
        /// collection of locations
        /// </summary>
        public ObservableCollection<Location> Locations { get; set; }
        /// <summary>
        /// sets the selected location
        /// </summary>
        private Location selectedLocation { get; set; }
        public Location SelectedLocation 
        {
            get { return selectedLocation; }
            set
            {
                selectedLocation = value;
                if(selectedLocation != null)
                {
                    App.location = selectedLocation;
                    App.Current.MainPage.Navigation.PushAsync(new CityInformation());
                }
            }
        }
        /// <summary>
        /// constructor
        /// </summary>
        public MainPageViewModel()
        {
            AddCityClickedCommand = new Command(AddCity);
            Locations = new ObservableCollection<Location>();
        }
        /// <summary>
        /// takes the user to the add city page
        /// </summary>
        private void AddCity()
        {
            App.Current.MainPage.Navigation.PushAsync(new AddCity());
        }
        /// <summary>
        /// displays the cities in the database
        /// </summary>
        public void OnAppearing()
        {

            List<Location> myLocations = new List<Location>();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {
                    conn.CreateTable<Location>(); //create if it doesn't exist
                    myLocations = conn.Table<Location>().ToList();
                }
                catch (Exception ex)
                {
                    _ = Application.Current.MainPage.DisplayAlert("Error", "No response from SQLite Database - " + ex.Message, "OK");
                }

            }

            Locations.Clear();
            foreach (Location location in myLocations)
            {
                Locations.Add(location);
            }

            //lstLocations.ItemsSource = myLocations;
        }

    }
}
