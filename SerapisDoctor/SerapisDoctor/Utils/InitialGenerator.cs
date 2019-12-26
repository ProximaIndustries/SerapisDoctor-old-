using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisDoctor.Utils
{
    public static class InitialGenerator
    {
        //get infomation from backend


        public static char GenerateFirstNameInitial(string _firstName)
        {
            _firstName = _firstName.Substring(0, 1).ToUpper();

            char firstLetter = _firstName[0];

            return firstLetter;
        }

        public static char GenerateSEcondNameInitial(string _middleName)
        {
            _middleName = _middleName.Substring(0, 1).ToUpper();

            char firstLetterOfMiddleName = _middleName[0];

            return firstLetterOfMiddleName;
        }
    }
}
