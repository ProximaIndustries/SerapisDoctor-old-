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
    public partial class ContentViewRenderer : ContentView
    {
        public static readonly BindableProperty ContentRenderProperty = BindableProperty.Create( 
        "Content", 
        typeof(ContentView), 
        typeof(ContentViewRenderer), 
        null, 
        propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((ContentViewRenderer)bindable).reelContent.Content = (ContentView)newValue;
        });

        public ContentView ContentViewRender
        {
            set { SetValue(ContentRenderProperty, value); }
            get { return (ContentView)GetValue(ContentRenderProperty); }
        }

        public ContentViewRenderer()
        {
            InitializeComponent();
        }
    }
}