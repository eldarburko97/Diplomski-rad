namespace eDentalClinic.Model
{
    public class BranchTreatment
    {
        public int BranchTreatmentID { get; set; }
        public int BranchID { get; set; }
        public int TreatmentID { get; set; }

        public Branch Branch { get; set; }
        public Treatment Treatment { get; set; }
    }
}
