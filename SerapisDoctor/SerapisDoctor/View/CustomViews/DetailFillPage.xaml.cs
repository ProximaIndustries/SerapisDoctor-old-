using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SerapisDoctor.View.CustomViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailFillPage : ContentView
    {
        public DetailFillPage()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty TextFieldProperty = BindableProperty.Create
            (
            "Text",
            typeof(string),
            typeof(DetailFillPage),
            null
            );

        public string Text
        {
            set { SetValue(TextFieldProperty, value); }
            get { return (string)GetValue(TextFieldProperty); }
        }

    }
}