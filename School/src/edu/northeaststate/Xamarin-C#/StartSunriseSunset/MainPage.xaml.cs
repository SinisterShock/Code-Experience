using SQLite;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

/// <summary>
/// Name: Tyler Burleson
/// File:xSunriseSunset
/// Project:Project5
/// Revision Date:4/11/2022
/// 
/// 
/// Error in the API Call when deserializing the object
/// </summary>
namespace XSunriseSunset
{
    /// <summary>
    /// Entry point to the code
    /// </summary>
    public partial class MainPage : ContentPage
    {
        public static List<Location> myLocations = new List<Location>();

        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Shows the database of cities chosen by the user
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            List<Location> myLocations = new List<Location>();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {
                    conn.CreateTable<Location>(); //create if it doesn't exist
                    myLocations = conn.Table<Location>().ToList();
                }
                catch(Exception ex)
                {
                    _ = DisplayAlert("Error", "No response from SQLite Database - " + ex.Message, "OK");
                }

            }//end OnAppearing                                  

            lstLocations.ItemsSource = myLocations;
        }

        /// <summary>
        /// opens the api tabbed page when the user clicks on a city
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstLocations_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Location loc = (Location)e.Item;
            App.loc = loc;
            Navigation.PushAsync(new CityTabbed());
        }//end lstLocations_ItemTapped

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCity_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddCity());
        }
    }//end MainPage
}//end namespace
