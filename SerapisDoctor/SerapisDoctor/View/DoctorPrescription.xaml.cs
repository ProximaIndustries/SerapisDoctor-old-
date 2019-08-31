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
	public partial class DoctorPrescription : ContentPage
	{
        DoctorPrescriptionViewModel viewModel;

        public DoctorPrescription ()
		{
			InitializeComponent ();
            viewModel = new DoctorPrescriptionViewModel();
            BindingContext = viewModel;

            viewModel.ButtonEvent += BeginButtonAnimation;
		}

        private void BeginButtonAnimation(object sender, EventArgs args)
        {
            tapCount.Scale = 1.4;
            Task.Delay(500);
            tapCount.ScaleTo(1, 250, Easing.SinIn);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DoctorPrescriptionPage.TranslationX = 0;
            DoctorPrescriptionPage.TranslationY = 2000;
            DoctorPrescriptionPage.TranslateTo(0, 0, 1000, Easing.SinInOut);
        }
    }
}