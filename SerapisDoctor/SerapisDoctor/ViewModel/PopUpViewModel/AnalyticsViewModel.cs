using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SerapisDoctor.Model;

namespace SerapisDoctor.ViewModel.PopUpViewModel
{
   
    public class AnalyticsViewModel:BaseViewModel
    {
        public Command CloseAnalytics { get; set; }

        public AnalyticsViewModel()
        {
            CloseAnalytics = new Command(async()=>await ClosePageAsync());
        }

        private async Task ClosePageAsync()
        {
           await PopupNavigation.Instance.PopAllAsync(true);
        }

        //Note: Ignore for now until Machine learning is introduced to the platform
        private async Task GenerateListAsync()
        {
            //Get information from the backend
            await Task.FromResult("");
        }

    }
}
