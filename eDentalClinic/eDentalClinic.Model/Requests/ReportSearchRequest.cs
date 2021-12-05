using System;
using System.Collections.Generic;
using System.Text;

namespace eDentalClinic.Model.Requests
{
    public class ReportSearchRequest
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
