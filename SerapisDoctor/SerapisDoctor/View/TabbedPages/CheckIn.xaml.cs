using SerapisDoctor.ViewModel.TabbedPageViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisDoctor.View.TabbedPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CheckIn : ContentPage
	{
        CheckInViewModel viewModel;

        public CheckIn ()
		{
			InitializeComponent ();
            viewModel = new CheckInViewModel();
            BindingContext = viewModel;
		}
	}
}