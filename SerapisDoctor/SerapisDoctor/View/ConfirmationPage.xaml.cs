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
	}
}