using System;
using System.Collections.Generic;
using System.Text;

namespace SerapisDoctor.Controls.Calendar
{
    [Flags]
    public enum CalandarChanges
    {
        MaxMin=1,
        StartDate=1<<1,
        StartDay=1<<2,
        All=MaxMin|StartDate|StartDay
    }
}
