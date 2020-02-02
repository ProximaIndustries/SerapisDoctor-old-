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
	public partial class MainTabPage : TabbedPage
	{
		TabbedMainViewModel viewModel;

		public MainTabPage ()
		{
			InitializeComponent ();
			viewModel = new TabbedMainViewModel();
			BindingContext = viewModel;
		}
	}
}