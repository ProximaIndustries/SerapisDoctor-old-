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
		}
	}
}