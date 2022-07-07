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
using XSunriseSunset.ViewModels;

namespace XSunriseSunset
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SunriseSunset : ContentPage
    {
        /// <summary>
        /// gives access to the view model
        /// </summary>
        private SunriseSunsetViewModel vm;

        /// <summary>
        /// constructor
        /// </summary>
        internal SunriseSunset()
        {
            InitializeComponent();
            vm = (SunriseSunsetViewModel)Resources["vm"];
        }

        /// <summary>
        /// calls the api
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.ReadAPIAsync();
        }
    }
}