using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisDoctor.Utils
{
    public interface IInitailGenerator
    {
        char FirstNameInitial(string firstName);
        char MiddleNameInital(string middleName);
    }
}
