using SerapisDoctor.ViewModel.SideMenuPageViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisDoctor.View.SideMenuPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Help : ContentPage
	{
        HelpViewModel viewModel;

		public Help ()
		{
			InitializeComponent ();
            viewModel = new HelpViewModel();
            BindingContext = viewModel;
		}
	}
}