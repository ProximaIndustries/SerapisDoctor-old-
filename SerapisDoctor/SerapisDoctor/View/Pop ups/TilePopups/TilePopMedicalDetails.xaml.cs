using Rg.Plugins.Popup.Pages;
using SerapisDoctor.ViewModel.PopUpViewModel.TilePopUpsViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisDoctor.View.Pop_ups.TilePopups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TilePopMedicalDetails : PopupPage
    {

        TilePopMdicalDetailsVM viewModel;

        public TilePopMedicalDetails()
        {
            InitializeComponent();

            viewModel = new TilePopMdicalDetailsVM();

            BindingContext = viewModel;

            //Event handler to start animation
            viewModel.ButtonPressEvent += ViewModel_ButtonPressEvent;
        }

        private void ViewModel_ButtonPressEvent(object sender, EventArgs args)
        {
            displayInfoPostioning.TranslationX = displayInfoPostioning.TranslationX;
            displayInfoPostioning.TranslationY = displayInfoPostioning.TranslationY;
            displayInfoPostioning.Scale = 1;
            ImageRow.Opacity = 1;

            ImageRow.FadeTo(1, 2000, Easing.SinOut);
            displayInfoPostioning.TranslateTo(-550, -30, 2600, Easing.SinIn);
            displayInfoPostioning.ScaleTo(0.65, 3000, Easing.SinIn);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            displayInformationGrid.Opacity = 0;
            displayInfoGridTwo.Opacity = 0;
            ImageRow.Opacity = 0;
            TitleRow.Opacity = 0;
            AddButtonRow.Opacity = 0;
            CloseButtonRow.Opacity = 0;

            displayInformationGrid.FadeTo(1, 2500, Easing.SinOut);
            displayInfoGridTwo.FadeTo(1, 2500, Easing.SinInOut);
            ImageRow.FadeTo(1, 2800, Easing.SinOut);
            TitleRow.FadeTo(1, 3000, Easing.SinOut);
            AddButtonRow.FadeTo(1, 3200, Easing.SinOut);
            CloseButtonRow.FadeTo(1, 3400, Easing.SinOut);
        }
    }
}