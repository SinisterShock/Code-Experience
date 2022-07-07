using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xAssignment3
{

    public partial class MainPage : ContentPage
    {
        //Establish and set the 5 bytes needed to represent the OR,AND, and ADD bits from the 1st and 2nd bit
        byte byte1 = 0b0;
        byte byte2 = 0b0;
        byte byte3 = 0b0;
        byte byte4 = 0b0;
        byte byte5 = 0b0;

        /// <summary>
        /// Entrance point for the code
        /// </summary>
        public MainPage()
        {
            InitializeComponent();
            
        }

       /// <summary>
       /// Sets the value of the first bit, to a one or a zero depending on the value of the switch and converts the OR, AND, and ADD bit to strings
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void swBit1_Toggled(object sender, ToggledEventArgs e)
        {
            if(e.Value == true)
            {
                byte1 = 0b1;
            }
            if(e.Value == false)
            {
                byte1 = 0b0;
            }

            byte3 = (byte)(byte1 & byte2); //AND
            byte4 = (byte)(byte1 | byte2); //OR
            byte5 = (byte)(byte1 + byte2); //AND
            
            string orBit = Convert.ToString((byte)byte4, 2);
            lblOrBit.Text = orBit;
            string andBit = Convert.ToString((byte)byte3, 2);
            lblAndBit.Text = andBit;
            string addBit = Convert.ToString((byte)byte5, 2);
            lblAddBit.Text = addBit;

        }

        /// <summary>
        /// Sets the value of the second bit, to a one or a zero depending on the value of the switch and converts the OR, AND, and ADD bit to strings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void swBit2_Toggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == true)
            {
                byte2 = 0b1;
            }
            if (e.Value == false)
            {
                byte2 = 0b0;
            }

            byte3 = (byte)(byte1 & byte2); //AND
            byte4 = (byte)(byte1 | byte2); //OR
            byte5 = (byte)(byte1 + byte2); //AND

            string orBit = Convert.ToString((byte)byte4, 2);
            lblOrBit.Text = orBit;
            string andBit = Convert.ToString((byte)byte3, 2);
            lblAndBit.Text = andBit;
            string addBit = Convert.ToString((byte)byte5, 2);
            lblAddBit.Text = addBit;
        }
    }
}
