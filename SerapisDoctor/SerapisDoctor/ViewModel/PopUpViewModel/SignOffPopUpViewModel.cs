using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Rg.Plugins.Popup.Services;
using SerapisDoctor.Model;

namespace SerapisDoctor.ViewModel.PopUpViewModel
{
    public class SignOffPopUpViewModel:BaseViewModel
    {
        public Command ClosePopPage { get; set; }

        public PrescriptionConfirmationPopUpModel PopUpInformation { get; set; }

        public SignOffPopUpViewModel()
        {
            ClosePopPage = new Command(async()=>await ClosePageAsync());
            InitalizePopUp();
        }

        private async Task ClosePageAsync()
        {
            await PopupNavigation.Instance.PopAllAsync(true);
        }

        private void InitalizePopUp()
        {
            PopUpInformation = new PrescriptionConfirmationPopUpModel();

            PopUpInformation.Title = "Presribe medication";

            //Note: This will load diffrent animations depending on what method is used for authenticating
            PopUpInformation.LottieAnimation = "Load Lottie animation";

            //Note: This will also have diffrent messages depebding on what prescription method is used
            PopUpInformation.Message = "Place your finger on the finger print scan";
        }

    }
}
