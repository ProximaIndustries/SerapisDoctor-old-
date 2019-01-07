using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SerapisDoctor.Model
{
    public class TileModel
    {
        public int Seq { get; set; }

        public string Text { get; set; }

        public DateTime Time { get; set; }

        public string BackgroundImage { get; set; }

        public ContentView Content { get; set; }
    }
}
