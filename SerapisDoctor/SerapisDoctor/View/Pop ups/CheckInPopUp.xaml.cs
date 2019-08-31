using Rg.Plugins.Popup.Pages;
using SerapisDoctor.ViewModel.PopUpViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisDoctor.View.Pop_ups
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CheckInPopUp : PopupPage
	{
        CheckInPopUpViewModel viewModel;

        public CheckInPopUp ()
		{
			InitializeComponent ();
            viewModel = new CheckInPopUpViewModel();
            BindingContext =viewModel;

            viewModel.ButtonEvent += AnimateButtonPress;
		}

        private void AnimateButtonPress(object sender, EventArgs args)
        {
            CheckInGrid.Scale = 1.4;
            Task.Delay(500);
            CheckInGrid.ScaleTo(1, 250, Easing.SinOut);
        }
    }
}