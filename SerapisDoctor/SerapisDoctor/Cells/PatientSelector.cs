using SerapisDoctor.Model.PatientModel;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SerapisDoctor.Cells
{
    public class PatientSelector:DataTemplateSelector
    {
        readonly DataTemplate cashTemplate, medicalAidTemplate;

        public PatientSelector()
        {
            cashTemplate = new DataTemplate(typeof(CashAidPatient));
            medicalAidTemplate = new DataTemplate(typeof(MedicalAidPatient));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var patientPayMethod=item as PatientMeta;

            if (patientPayMethod.IsMedicalAidPatient == true)
            {
                return medicalAidTemplate;
            }
            else
            {
                return cashTemplate;
            }
        }

    }
}
