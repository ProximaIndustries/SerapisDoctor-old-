using SerapisDoctor.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Rg.Plugins.Popup.Pages;

namespace SerapisDoctor.ViewModel.PopUpViewModel
{
    public class ErrorPopUpViewModel
    {
        public Color ErrorBackGroundColour { get; set; }

        public string TextColour { get; set; }

        const string textColour = "Black";

        public string ErrorMessage { get; set; }

        private PopupPage errorPage;

        public ErrorPopUpViewModel()
        {
            InitalizeErrorMessage();
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
