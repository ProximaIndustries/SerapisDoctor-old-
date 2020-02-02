using SerapisDoctor.Model.PatientModel;
using SerapisDoctor.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Rg.Plugins.Popup.Services;
using SerapisDoctor.Model.PopUpModel;

namespace SerapisDoctor.ViewModel.PopUpViewModel.TilePopUpsViewModel
{
    public class TilePopMdicalDetailsVM:BaseViewModel
    {
        //Note: A lot of work still needs to be done here.

        public delegate void AddButtonEventHandler(object sender, EventArgs args);

        public event AddButtonEventHandler ButtonPressEvent;

        public void RaisButtonPressedEvent()
        {
            if (ButtonPressEvent != null)
                ButtonPressEvent(this, new EventArgs());
        }

        public List<object> ListOfConditions { get; set; }


        #region Properties
        private double transY;

        public double TransY
        {
            get
            {
                return transY;
            }
            set
            {
                transY = value;
                OnPropertyChanged("TransY");
                transY = value;
            }
        }

        private double scaler=1;

        public double Scaler
        {
            get
            {
                return scaler;
            }
            set
            {
                scaler = value;
                OnPropertyChanged("Scaler");
                scaler = value;
            }
        }


        private double transX;

        public double Transx
        {
            get
            {
                return transX;
            }
            set
            {
                transX = value;
                OnPropertyChanged("Transx");
                transX = value;
            }
        }


        private string imageIcon;
        public string ImageIcon
        {
            get
            {
                return imageIcon;
            }
            set
            {
                imageIcon = value;
                OnPropertyChanged("ImageIcon");
                imageIcon = value;
            }
        }

        private string title;
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged("Title");
                title = value;
            }
        }

        private bool viewVisability=true;

        public bool ViewVisability
        {
            get
            {
                return viewVisability;
            }
            set
            {
                viewVisability = value;
                OnPropertyChanged("ViewVisability");
                viewVisability = value;
            }
        }

        public Command AddToPatientInfo { get; set; }

        public Command CloseDetailPage { get; set; }
        #endregion

        #region constant Image address/ other local constants
        private const string MedicalFilesNote = "TileFolderIcon.png";
        private const string ChronicDiseases = "TileChronicIcon.png";
        private const string AllergiesTile = "TileAllergiesIcon.png";
        private const string Medications = "TileMedicationIcon.png";
        private const string TitleMedication = "Medication";
        private const string TitleChronic = "Chronic Disease(s)";
        private const string TitleAllergies = "Allergies";
        private const string TitleMedicalFileNote = "Medical Files/Notes";
        #endregion

        public TilePopMdicalDetailsVM()
        {
            CloseDetailPage = new Command(ClosePage);

            AddToPatientInfo = new Command(AddInformationToPatient);

            MessagingCenter.Subscribe<PatientDetailsViewModel, PatientMedDetailPopUPModel>(this, MessagingKeys.MedicalDetails, (sender, arg) => 
            {
                InitalizeTile(arg.TileTitle, arg.Conditions);
            });

        }

        private void AddInformationToPatient()
        {
            RaisButtonPressedEvent();

            //sets the property
            SetVisability();

            //Diable the button
            IsButtonEnabled = false;
        }

        private void SetVisability()
        {
            //set field to visable
            ViewVisability = false;
        }

        private void ClosePage()
        {
            ViewVisability = true;

            IsButtonEnabled = true;

            Transx = 0;

            TransY = 0;

            Scaler = 1;

            PopupNavigation.Instance.PopAllAsync(true);
        }

        private void InitalizeTile(string _patientObj, List<object> _list)
        {
            switch (_patientObj)
            {
                case "MedicalFilesPopCode":
                    ImageIcon = MedicalFilesNote;
                    Title = TitleMedicalFileNote;
                    ListInitalizer(_list);
                    break;

                case "MedicationPopCode":
                    ImageIcon = Medications;
                    Title = TitleMedication;
                    ListInitalizer(_list);
                    break;

                case "AllergiesPopCode":
                    ImageIcon = AllergiesTile;
                    Title = TitleAllergies;
                    ListInitalizer(_list);
                    break;

                case "ChronicPopCode":
                    ImageIcon = ChronicDiseases; 
                    Title = TitleChronic;
                    ListInitalizer(_list);
                    break;

                default:
                    //Print error message
                    break;
            }
        }

        //Void for now, must copy each item to the local list
        private List<object> ListInitalizer(List<object> useList)
        {
            ListOfConditions = new List<object>() 
            {
                "Item 1", 
                "Item 2", 
                "Item 3" 
            };

            //ListOfConditions = useList;

            return ListOfConditions;
        }

        //Use to clear anything in memory to increase performace, also unsubsrcibe from subcription in MessagingCenter
        ~TilePopMdicalDetailsVM()
        {
            
        }

    }
}
