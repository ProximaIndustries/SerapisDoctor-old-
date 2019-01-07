using SerapisDoctor.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisDoctor.View.Templates
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SummaryTemplate : ContentView
	{

        ConfirmationViewModel viewModel;

        public SummaryTemplate ()
		{
			InitializeComponent ();
            viewModel = new ConfirmationViewModel();
            BindingContext = viewModel;
		}
	}
}