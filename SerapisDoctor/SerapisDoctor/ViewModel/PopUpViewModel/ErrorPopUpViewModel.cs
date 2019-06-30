using SerapisDoctor.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Rg.Plugins.Popup.Pages;

namespace SerapisDoctor.ViewModel.PopUpViewModel
{
    public class ErrorPopUpViewModel:BaseViewModel
    {
      
        public string TextColour { get; set; }

        const string textColour = "White";

        public string ErrorMessage { get; set; }

        public ErrorPopUpViewModel()
        {
            InitalizeErrorMessage();
        }

        //Need to fix the on property changed property to be able to change the notification background colour
        //Placed in comments cause it throws null excpetions for some reason
        private Color errorBackground = Color.White;
        public Color ErrorBackGroundColour
        {
            get
            {
                return errorBackground;
            }
            set
            {
                if (errorBackground != value)
                {
                    errorBackground = Color.Red;
                    //OnPropertyChanged("ErrorBackGroundColour");
                    errorBackground = value;
                }
                else
                {
                    errorBackground = Color.White;
                    //OnPropertyChanged("ErrorBackGroundColour");
                }
            }
        }

        private void RemoveErrorMessage(string message)
        {
            ErrorBackGroundColour = Color.Green;
            TextColour = "White";
            ErrorMessage = message;
        }

        private void InitalizeErrorMessage()
        { 
            ErrorMessage = "No connection";
            TextColour = textColour;
            ErrorBackGroundColour = Color.Red;
        }

        ~ErrorPopUpViewModel()
        {
            ErrorBackGroundColour = Color.Green;
            TextColour = textColour;
            ErrorMessage = "Connected";
        }
    }
}
