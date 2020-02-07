using SerapisDoctor.Model.Doctor;
using SerapisDoctor.Services.Calendar;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SerapisDoctor.ViewModel.TabbedPageViewModels
{
    public class ScheduleViewModel:BaseViewModel
    {
        #region Properties
        //Get from app settings
        string PracticeCloseTime = "17:00:00";

        //Get from app settings
        string PracticeOpenTime = "08:30:00";

        public List<int> HoursOfOperation { get; set; }
        public ObservableCollection<Doctor> Doctors { get; set; }

        private int hour;

        public int Hour
        {
            get
            {
                return hour;
            }
            set
            {
                hour = value;
                OnPropertyChanged("Hour");
                hour = value;
            }
        }
        #endregion Properties
        public ScheduleViewModel()
        {
           InitalizeSchedule();
           GenerateDoctorList();
        }

        private void InitalizeSchedule()
        {
            HoursOfOperation = new List<int>();

            DateTime parseOpenTime = DateTime.Parse(PracticeOpenTime);

            DateTime parseCloseTime = DateTime.Parse(PracticeCloseTime);

            TimeSpan operationsHours = parseCloseTime-parseOpenTime;

            var tempVar = parseOpenTime;

            for (int i = 0; i < operationsHours.TotalHours; i++)
            {
                HoursOfOperation.Add(i);
                tempVar = tempVar.AddHours(1);
            }

            PopulateDateEvents();

        }
        private void GenerateDoctorList()
        {
            Doctors = new ObservableCollection<Doctor>
                  {
                    new Doctor{ LastName = "Zulu ",ProfilePicture="userplaceholder.png" },
                    new Doctor{ LastName = "Duma ",ProfilePicture="userplaceholder.png"},
                    new Doctor{ LastName = "Moody ",ProfilePicture="userplaceholder.png"},
                    new Doctor{ LastName = "McGhee ", ProfilePicture="userplaceholder.png"},
                    new Doctor{ LastName = "Naidoo", ProfilePicture="userplaceholder.png"},
                    new Doctor{ LastName = "Ngwenya ",ProfilePicture="userplaceholder.png"},
            };
        }


        static List<object> events = new List<object>();

        //Used for test purposes
        public static void  PopulateDateEvents()
        {
            try
            {
                foreach (var item in CalendarEventsData.GetEventsOutLookDataDummy())
                {
                    events.Add(item);
                }
            }
            catch (NullReferenceException)
            {

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
