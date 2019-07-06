using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SerapisDoctor.Utils
{
    //This must run in the background and keep track of how long the practice has been open for 

    public class PracticeOperationTimeKeeper
    {
        //Get practiceOpHours from the users settings
        public PracticeOperationTimeKeeper(string practiceOpHours)
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), ()=> 
            {
                return true;
            });
        }
    }
}
