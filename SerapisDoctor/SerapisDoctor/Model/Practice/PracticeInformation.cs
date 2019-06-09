namespace SerapisDoctor.Model.Practice
{
    public class PracticeInformation
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string PracticeName { get; set; }

        public Address PracticeAddress { get; set; }

        public double DistanceFromPractice { get; set; }
    }

}
