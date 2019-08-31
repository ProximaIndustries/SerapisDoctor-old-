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
	public partial class PatientInWaiting : ContentPage
	{
        DiagnosisListViewModel viewModel;

        public PatientInWaiting ()
		{
			InitializeComponent();
            viewModel = new DiagnosisListViewModel();
            BindingContext = viewModel;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            dignosisPage.Opacity = 0;
            doctorDetails.Opacity = 0;
            DiagnosisList.Opacity = 0;

            dignosisPage.FadeTo(1, 1000, Easing.SinInOut);
            doctorDetails.FadeTo(1, 1200, Easing.SinInOut);
            DiagnosisList.FadeTo(1, 1400, Easing.SinInOut);

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            DiagnosisList.FadeTo(0, 1000, Easing.SinInOut);
            doctorDetails.FadeTo(0, 1200, Easing.SinInOut);
            dignosisPage.FadeTo(0, 1400, Easing.SinInOut);
        }
    }
}