using SQLite;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XSunriseSunset.ViewModels;

namespace XSunriseSunset
{
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// gives access to the api
        /// </summary>
        private MainPageViewModel vm;
        /// <summary>
        /// establishes a list of locations
        /// </summary>
        public static List<Location> myLocations = new List<Location>();
        /// <summary>
        /// constructor
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            vm = (MainPageViewModel)Resources["vm"];
        }

        /// <summary>
        /// calls the api
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.OnAppearing();
        }


    }
}
