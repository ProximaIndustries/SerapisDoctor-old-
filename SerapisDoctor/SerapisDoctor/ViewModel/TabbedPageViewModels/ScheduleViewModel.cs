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
                    new Doctor{ LastName = "Zulu ", VarsityAttended="MBchB(Ukzn)",PhotoUrl="userplaceholder.png" },
                    new Doctor{ LastName = "Duma ", VarsityAttended="MBchB(UWC),FC Orth(SA)",PhotoUrl="userplaceholder.png"},
                    new Doctor{ LastName = "Moody ", VarsityAttended="MBchB(Wits)",PhotoUrl="userplaceholder.png"},
                    new Doctor{ LastName = "McGhee ", VarsityAttended="MBchB(Stellenbosch)",PhotoUrl="userplaceholder.png"},
                    new Doctor{ LastName = "Naidoo", VarsityAttended="MBchB(Ukzn)",PhotoUrl="userplaceholder.png"},
                    new Doctor{ LastName = "Ngwenya ", VarsityAttended="MBchB(UFS)",PhotoUrl="userplaceholder.png"},
            };
        }


        static List<object> events = new List<object>();

        //Used for test purposes
        public static void  PopulateDateEvents()
        {
            try
            {
                foreach (var item in OutlookCalendar.GetEventsOutLookDataDummy())
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
