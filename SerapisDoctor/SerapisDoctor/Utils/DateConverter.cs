using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisDoctor.Utils
{
    public class DateConverter
    {
        private string Month { get; set; }

        public DateConverter()
        {
            
        }

        public string ConvertMonth(int todaysDate)
        {
            string month;

            switch (todaysDate)
            {
                case 1:
                    month = "January";
                    Month = month;
                    break;

                case 2:
                    month = "February";
                    Month = month;
                    break;

                case 3:
                    month = "March";
                    Month = month;
                    break;

                case 4:
                    month = "April";
                    Month = month;
                    break;

                case 5:
                    month = "May";
                    Month = month;
                    break;

                case 6:
                    month = "June";
                    Month = month;
                    break;

                case 7:
                    month = "July";
                    Month = month;
                    break;

                case 8:
                    month = "August";
                    Month = month;
                    break;

                case 9:
                    month = "September";
                    Month = month;
                    break;

                case 10:
                    month = "October";
                    Month = month;
                    break;

                case 11:
                    month = "November";
                    Month = month;
                    break;

                case 12:
                    month = "December";
                    Month = month;
                    break;
            }

            return Month;
        }
    }
}
