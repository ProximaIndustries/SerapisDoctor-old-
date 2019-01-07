using SerapisDoctor.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisDoctor.ViewModel
{
    public class AddDoctorsNoteViewModel:BaseViewModel
    {

        //instance for date conversion
        DateConverter dateConverter = new DateConverter();

        public AddDoctorsNoteViewModel()
        {
            InitalizeDate();
        }

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

        private string InitalizeDate()
        {
            //The follwoing converts the month from an interger to human readable dates like march,april etc
            return todaysDate = DateTime.Today.Day + " " + dateConverter.ConvertMonth(DateTime.Today.Month) + " " + DateTime.Today.Year;
        }

    }
}
