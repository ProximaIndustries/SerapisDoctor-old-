using SerapisDoctor.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Rg.Plugins.Popup.Pages;
using SerapisDoctor.ViewModel.TabbedPageViewModels;
using SerapisDoctor.Utils;

namespace SerapisDoctor.ViewModel.PopUpViewModel
{
    public class ErrorPopUpViewModel:BaseViewModel
    {
      
        public string TextColour { get; set; }

        const string textColour = "White";

        private string errorMessage;
        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }

            set
            {
                errorMessage = value;
                OnPropertyChanged("ErrorMessage");
                errorMessage = value;
            }
        }

        public ErrorPopUpViewModel()
        {
            MessagingCenter.Subscribe<CheckInViewModel, string>(this, MessagingKeys.ErrorPopUpBanner, (arg, sender) => 
            {
                InitalizeErrorMessage(sender);
            });

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
                    //errorBackground = value;
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

        private void InitalizeErrorMessage(string msg)
        { 
            if(msg=="Connection error" || msg==null)
            {
                ErrorMessage = "No connection";
                TextColour = textColour;
                ErrorBackGroundColour = Color.Red;
            }
            else
            {
                ErrorBackGroundColour = Color.Green;
                TextColour = textColour;
                ErrorMessage = "Connected";
            }
        }

        ~ErrorPopUpViewModel()
        {
            //Unsubscribe to the messaging center
        }
    }
}
