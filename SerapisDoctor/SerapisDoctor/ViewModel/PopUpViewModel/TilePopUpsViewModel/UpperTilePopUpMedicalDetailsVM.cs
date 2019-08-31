using SerapisDoctor.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SerapisDoctor.ViewModel.PopUpViewModel.TilePopUpsViewModel
{
    public class UpperTilePopUpMedicalDetailsVM:BaseViewModel
    {
        
        public UpperTilePopUpMedicalDetailsVM()
        {
            MessagingCenter.Subscribe<PatientDetailsViewModel, string>(this, MessagingKeys.UpperTilePopUp, (sender, arg) =>
            {
                InitalizeUpperPopUp(arg);
            });
        }

        private void InitalizeUpperPopUp(string _property)
        {
            switch (_property)
            {
                case "DOB":
                    TileHeaderGenerator("Age", "TileAgeIcon.png");
                    break;

                case "BloodType":
                    TileHeaderGenerator("Blood type", "TileBloodIcon.png");
                    break;

                case "Pressure":
                    TileHeaderGenerator("Blood Pressure", "TileBloodPressureIcon.png");
                    break;

                case "Gender":
                    TileHeaderGenerator("Gender", "TileGenderIcon.png");
                    break;

                default:
                    break;
            }
        }

        private void TileHeaderGenerator(string _title, string _icon)
        {
            Title = _title;

            ImageIcon = _icon;
        }
    }
}
