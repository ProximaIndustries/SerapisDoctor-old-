using SerapisDoctor.Model.Enum;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace SerapisDoctor.Utils
{
    public class EnumToStringConverter : IValueConverter
    {
        private string CapitalizeFirstLetter(string _string)
        {
            var partOne=_string.Substring(0).ToUpper();

            var partTwo=_string.Substring(1);

            return string.Format("{0}{1}", partOne, partTwo);
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case MedicationType.bandage:
                    return (string)CapitalizeFirstLetter(MedicationType.bandage.ToString());

                case MedicationType.capsule:
                    return (string)CapitalizeFirstLetter(MedicationType.capsule.ToString());

                case MedicationType.ointment:
                    return (string)CapitalizeFirstLetter(MedicationType.pills.ToString());

                case MedicationType.pills:
                    return (string)CapitalizeFirstLetter(MedicationType.pills.ToString());

                case MedicationType.syringe:
                    return (string)CapitalizeFirstLetter(MedicationType.syringe.ToString());

                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (MedicationType)value;
        }
    }
}
