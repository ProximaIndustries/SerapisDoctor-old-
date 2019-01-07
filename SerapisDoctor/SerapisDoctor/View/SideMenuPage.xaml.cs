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
	public partial class SideMenuPage : ContentPage
	{
        SideMenuViewModel viewModel;

        public SideMenuPage ()
		{
			InitializeComponent ();
            viewModel = new SideMenuViewModel();
            BindingContext = viewModel;
		}
	}
}