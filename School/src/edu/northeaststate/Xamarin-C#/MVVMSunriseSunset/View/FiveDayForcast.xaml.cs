
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XSunriseSunset.ViewModels;

namespace XSunriseSunset
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FiveDayForcast : ContentPage
    {
        /// <summary>
        /// adds access to the view models
        /// </summary>
        private FiveDayForcastViewModel vm;
        /// <summary>
        /// constructor
        /// </summary>
        public FiveDayForcast()
        {
            InitializeComponent();
            vm = (FiveDayForcastViewModel)Resources["vm"];
        }
        /// <summary>
        /// runs the api
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.ReadAPIForcastWeatherDataAsync();
        }


    }
}