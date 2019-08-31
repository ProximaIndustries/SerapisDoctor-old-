using SerapisDoctor.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Rg.Plugins.Popup.Services;
using System.Threading.Tasks;
using SerapisDoctor.Model.Doctor;

namespace SerapisDoctor.ViewModel
{
    public class AddDoctorsNoteViewModel:BaseViewModel
    {

        //instance for date conversion
        DateConverter dateConverter = new DateConverter();

        public AddDoctorsNoteViewModel()
        {
            InitalizeDate();

            SaveDoctorsNote = new Command(async() => await SaveDocNoteAsync());
        }


        public Command SaveDoctorsNote { get; set; }

        private string todaysDate;
        public string  TodaysDate
        {
            get
            {
                return todaysDate;
            }
            set
            {
                todaysDate = value;
                OnPropertyChanged("TodaysDate");
                todaysDate = value;
            }
        }


        private string patientsNote;

        public string PatientsNote
        {
            get
            {
                return patientsNote;
            }
            set
            {
                patientsNote = value;
                OnPropertyChanged("PatientsNote");
                patientsNote = value;
            }
        }


        private string InitalizeDate()
        {
            //The follwoing converts the month from an interger to human readable dates like march,april etc
            return todaysDate = DateTime.Today.Day + " " + dateConverter.ConvertMonth(DateTime.Today.Month) + " " + DateTime.Today.Year;
        }

        private async Task SaveDocNoteAsync()
        {
            //Closes the pop up and adds the note to the current patient
            DoctorsNote note = new DoctorsNote()
            {
                 DateOfNote=TodaysDate,
                 Note=PatientsNote,
                 //Get from the config file
                 DoctorsName=""
            };

            MessagingCenter.Instance.Send<AddDoctorsNoteViewModel, DoctorsNote>(this, MessagingKeys.MedicalNoteAndFile, note);

            await Task.FromResult(PopupNavigation.Instance.PopAllAsync(true));
        }

    }
}
