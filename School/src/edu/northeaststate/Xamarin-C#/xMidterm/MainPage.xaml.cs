using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xMidterm
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// directs to the new city apge
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCity_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddCity());
        }
        /// <summary>
        /// Takes the tapped cities data and brings it over to a new Sunrise API page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstLocations_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            App.city = (City)e.Item;
            Navigation.PushAsync(new SunriseSunset());
        }
        /// <summary>
        /// Constanly Updates the main page to have the rows in the database
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            List<City> cities = new List<City>();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                //creates table
                conn.CreateTable<City>();   
                cities = conn.Table<City>().ToList();

                lstLocations.ItemsSource = cities;
                conn.Close();
            }
        }
    }
}
