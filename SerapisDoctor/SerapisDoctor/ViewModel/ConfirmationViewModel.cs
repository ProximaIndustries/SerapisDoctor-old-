using SerapisDoctor.Model;
using SerapisDoctor.View.Templates;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using CarouselView.FormsPlugin.Abstractions;

namespace SerapisDoctor.ViewModel
{
    public class ConfirmationViewModel:BaseViewModel
    {
        public ConfirmationViewModel()
        {
            CarouselPages();
        }

        //public ICommand SummeryCommand => new Command(NavigateToCarousel);

        private ObservableCollection<TileModel> tile;
        public ObservableCollection<TileModel> Tile
        {
            get
            {
                return tile;
            }
            set
            {
                tile = value;
            }
        }

        private int myPostion;
        public int MyPostion
        {
            get
            {
                return myPostion;
            }
            set
            {
                myPostion = value;
            }
        }

        TileContent contentMeds = new TileContent()
        {
             MContent=new MedicationContent
             {
                  MedicationImage= "ic_brightness_1.png",
                   MedicationName="Oxycon"
             }
        };

        private void CarouselPages()
        {
        
            Tile = new ObservableCollection<TileModel>()
            {
                 new TileModel
                 {
                     Seq =0,
                     Text ="Medication summery",
                     BackgroundImage ="MedicationSummeryBackground.png",
                     Content=new MedicationSummery()
                 },

                 new TileModel
                 {
                     Seq =1,
                     Text ="Check in summery",
                     BackgroundImage ="CheckOutBackground.png"
                 },

                 new TileModel
                 {
                     Seq =2,
                     Text ="Medical note/file summery",
                     BackgroundImage ="FileSummeryBackground.png"
                 }
            };
        }

    }
}
