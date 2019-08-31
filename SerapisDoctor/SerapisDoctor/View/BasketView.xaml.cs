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
	public partial class BasketView : ContentPage
	{
        BusketViewViewModel viewModel;

        public BasketView ()
		{
			InitializeComponent ();
            viewModel = new BusketViewViewModel();
            BindingContext = viewModel;

            viewModel.ButtonEvent += ButtonAnimtion;
		}

        private void ButtonAnimtion(object sender, EventArgs args)
        {
            ConfirmButtonGrid.Scale = 1.4;
            Task.Delay(500);
            ConfirmButtonGrid.ScaleTo(1, 250, Easing.SinOut);
        }
    }
}