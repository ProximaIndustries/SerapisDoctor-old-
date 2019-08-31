using SerapisDoctor.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisDoctor.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConfirmationPage : ContentPage
	{
        ConfirmationViewModel viewModel;

        public ConfirmationPage ()
		{
			InitializeComponent ();
            viewModel = new ConfirmationViewModel();
            BindingContext = viewModel;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            #region initial animation values
            Confirmation.Opacity = 0;
            PatientDocUserDetails.Opacity = 0;
            BoxLine.Opacity = 0;
            CarouselViewGrid.Opacity = 0;
            FingerPrintIconGrid.Opacity = 0;
            #endregion

            #region Animations
            Confirmation.FadeTo(1, 3000, Easing.SinInOut);

            PatientDocUserDetails.FadeTo(1, 3200, Easing.SinInOut);

            BoxLine.FadeTo(1, 3300, Easing.SinInOut);

            CarouselViewGrid.FadeTo(1, 3400, Easing.SinInOut);

            FingerPrintIconGrid.FadeTo(1, 3500, Easing.SinInOut);
            #endregion
        }
    }
}