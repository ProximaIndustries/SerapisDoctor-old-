using Rg.Plugins.Popup.Pages;
using SerapisDoctor.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisDoctor.View.Pop_ups
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DoctorsNote : PopupPage
	{

        AddDoctorsNoteViewModel viewModel;

        public DoctorsNote ()
		{
			InitializeComponent ();
            viewModel = new AddDoctorsNoteViewModel();
            BindingContext = viewModel;
		}
	}
}