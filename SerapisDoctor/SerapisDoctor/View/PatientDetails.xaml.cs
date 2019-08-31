using SerapisDoctor.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisDoctor.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PatientDetails : ContentPage
	{
        PatientDetailsViewModel viewModel;

        public PatientDetails ()
		{
			InitializeComponent ();
            viewModel = new PatientDetailsViewModel();
            BindingContext = viewModel;

            viewModel.ButtonEvent += BeginAnimation;

        }

        private void BeginAnimation(object sender, EventArgs args)
        {
            PrecriptionButton.Scale = 1.4;
            Task.Delay(500);
            PrecriptionButton.ScaleTo(1, 250, Easing.SinIn);
        }

        protected override void OnAppearing()
        {
            //Note that the Random Class plays a role in making new animations random every time the ui is loaded

            base.OnAppearing();

            Random randomInit;

            #region Animation Init values
            AgeTileGrid.Scale = 0;
            BloodTypeGrid.Scale = 0;
            BloodPressureGrid.Scale = 0;
            GenderGrid.Scale = 0;
            ChronicDiseaseGrid.Scale = 0;
            MedicalFileGrid.Scale = 0;
            MedicationGrid.Scale = 0;
            AllergiesGrid.Scale = 0;
            AddFileButtonGrid.Opacity = 0;
            DoctorNoteGrid.Opacity = 0;
            PrescriptionFillGrid.Opacity = 0;
            PageLoadAnimation.Opacity = 0;
            PatientId.Opacity = 0;
            #endregion

            PageLoadAnimation.FadeTo(1, 800, Easing.CubicInOut);

            randomInit = new Random();
            PatientId.FadeTo(1, (uint)randomInit.Next(1000, 2000), Easing.Linear);

            #region Tile Animations
            randomInit = new Random();
            AgeTileGrid.ScaleTo(1, (uint)randomInit.Next(1000, 2000), Easing.SinOut);

            randomInit = new Random();
            BloodPressureGrid.ScaleTo(1, (uint)randomInit.Next(1000, 2000), Easing.SinInOut);

            randomInit = new Random();
            BloodTypeGrid.ScaleTo(1, (uint)randomInit.Next(1000, 2000), Easing.SinOut);

            randomInit = new Random();
            GenderGrid.ScaleTo(1, (uint)randomInit.Next(1000, 2000), Easing.SinInOut);

            randomInit = new Random();
            ChronicDiseaseGrid.ScaleTo(1, (uint)randomInit.Next(1000, 2000), Easing.SinInOut);

            randomInit = new Random();
            MedicalFileGrid.ScaleTo(1, (uint)randomInit.Next(1000, 2000), Easing.SinInOut);

            randomInit = new Random();
            MedicationGrid.ScaleTo(1, (uint)randomInit.Next(1, 1000), Easing.SinInOut);

            randomInit = new Random();
            AllergiesGrid.ScaleTo(1, (uint)randomInit.Next(1, 1000), Easing.SinInOut);
            #endregion

            #region Button Animations
            randomInit = new Random();


            randomInit = new Random();
            AddFileButtonGrid.FadeTo(1 , (uint)randomInit.Next(1000, 2000), Easing.Linear);

            randomInit = new Random();
            DoctorNoteGrid.FadeTo(1, (uint)randomInit.Next(1000, 2000), Easing.Linear);

            randomInit = new Random();
            PrescriptionFillGrid.FadeTo(1, (uint)randomInit.Next(1000, 2000), Easing.Linear);
            #endregion
        }
    }
}