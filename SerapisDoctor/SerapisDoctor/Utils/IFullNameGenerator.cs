using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisDoctor.Utils
{
    public interface IFullNameGenerator
    {
        string FullName(string firstName, string surname);
    }
}
