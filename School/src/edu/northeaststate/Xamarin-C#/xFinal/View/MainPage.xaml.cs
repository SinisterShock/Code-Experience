using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using xFinal.ViewModel;
/// <summary>
/// Name: Tyler Burleson
/// Date: 4/03/2022
/// Email: tburles6@stumail.northeaststate.edu
/// </summary>
namespace xFinal
{
    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Gives access to the ViewModel File
        /// </summary>
        private TideViewModel vm;
        /// <summary>
        /// Constructor
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            vm = (TideViewModel)Resources["vm"];
        }
        /// <summary>
        /// Calls the api
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.ReadAPIAsync();
        }
    }
}
