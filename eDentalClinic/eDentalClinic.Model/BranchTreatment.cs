using System;
using System.Collections.Generic;
using System.Text;

namespace eDentalClinic.Model
{
  public  class BranchTreatment
    {
        public int BranchID { get; set; }
        public int TreatmentID { get; set; }

        public Branch Branch { get; set; }
        public Treatment Treatment { get; set; }
    }
}
