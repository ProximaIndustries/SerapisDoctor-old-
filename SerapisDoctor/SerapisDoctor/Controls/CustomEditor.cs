using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SerapisDoctor.Controls
{
    public class CustomEditor:Editor
    {
        public CustomEditor()
        {
            TextChanged += CustomEditor_TextChanged;
        }

        private void CustomEditor_TextChanged(object sender, TextChangedEventArgs e)
        {
            InvalidateMeasure();
        }
    }
}
