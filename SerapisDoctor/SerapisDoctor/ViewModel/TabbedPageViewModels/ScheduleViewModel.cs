using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisDoctor.ViewModel.TabbedPageViewModels
{
    public class ScheduleViewModel:BaseViewModel
    {
        //Get from app settings
        string PracticeCloseTime = "17:00:00";

        //Get from app settings
        string PracticeOpenTime = "08:30:00";

        public List<int> HoursOfOperation { get; set; }

        public ScheduleViewModel()
        {
           InitalizeSchedule();
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

        }


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
                hour=value;
            }
        }

    }
}
