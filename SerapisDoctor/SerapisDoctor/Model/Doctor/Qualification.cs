﻿using SerapisDoctor.Model.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisDoctor.Model.Doctor
{
    public class Qualification
    {
        
        public string Degree { get; set; }

        
        public long Graduated { get; set; }

        
        public string University { get; set; }


        public string Abbr { get; set; }

        
        public Specilization Specilization { get; set; }

        
        public string Specilizationabbr { get; set; }
    }
}
