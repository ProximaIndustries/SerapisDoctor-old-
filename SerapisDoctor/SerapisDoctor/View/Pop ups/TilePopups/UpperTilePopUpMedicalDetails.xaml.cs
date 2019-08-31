using SerapisDoctor.ViewModel.PopUpViewModel.TilePopUpsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisDoctor.View.Pop_ups.TilePopups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpperTilePopUpMedicalDetails : PopupPage
    {
        UpperTilePopUpMedicalDetailsVM viewModel;
        public UpperTilePopUpMedicalDetails()
        {
            InitializeComponent();
            viewModel = new UpperTilePopUpMedicalDetailsVM();
            BindingContext = viewModel;
        }
    }
}