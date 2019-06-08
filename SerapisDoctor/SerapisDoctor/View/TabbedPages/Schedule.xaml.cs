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
	public partial class Schedule : ContentPage
	{
        ScheduleViewModel viewModel;

        public Schedule ()
		{
			InitializeComponent ();

            viewModel = new ScheduleViewModel();

            BindingContext = viewModel;
		}
	}
}