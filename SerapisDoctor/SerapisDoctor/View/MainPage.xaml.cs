using SerapisDoctor.View.TabbedPages;
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
	public partial class MainPage : MasterDetailPage
	{

        MainPageViewModel viewModel;

        public MainPage ()
		{
			InitializeComponent ();
            Detail = new NavigationPage(new MainTabPage());
            NavigationPage.SetHasNavigationBar(this, false);
            viewModel = new MainPageViewModel();
            BindingContext = viewModel;
		}
	}
}