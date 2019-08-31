using SerapisDoctor.Model.Enum;
using System;
using System.Globalization;
using Xamarin.Forms;

namespace SerapisDoctor.Utils
{
    public class EnumToImageConverter : IValueConverter
    {
        private void LoadImagine()
        {

        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch (value)
            {
                case MedicationType.bandage:
                    return "";

                case MedicationType.capsule:
                    return "";

                case MedicationType.ointment:
                    return "";

                case MedicationType.pills:
                    return "";

                case MedicationType.syringe:
                    return "";

                default:
                    return"";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
