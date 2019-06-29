using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using SerapisDoctor.ViewModel.PopUpViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisDoctor.View.Pop_ups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ErrorPopUp : PopupPage
    {
        ErrorPopUpViewModel viewModel;

        public ErrorPopUp()
        {
            InitializeComponent();
            viewModel = new ErrorPopUpViewModel();
            BindingContext = viewModel;
        }
    }
}