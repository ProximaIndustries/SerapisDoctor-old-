using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisDoctor.Model.Patient
{
    public class PateintMeta
    {
        //Is going to be the mongodb id number
        public int id { get; set; }

        public string FullName { get; set; }

        public string ProfilePicture { get; set; }

        public int LineNumber { get; set; }
    }
}
