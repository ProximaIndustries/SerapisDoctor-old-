using SerapisDoctor.Services;
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
	public partial class CheckOut : ContentPage
	{

        CheckOutViewModel viewModel;

        public CheckOut ()
		{
			InitializeComponent ();
            viewModel = new CheckOutViewModel();
            BindingContext = viewModel;

        }

        //Note: Not sure if this violates MVVM rules but the only way to update the Ui in a tab since it is initalized on load
        //Is using the onAppearing method to render any changes and this is the only way of doing it.
        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.List.Clear();

            foreach (var patients in PatientsWaintingLineDb.GetPatientsAsync().Result)
            {
                viewModel.List.Add(patients);
            }
        }
    }
}