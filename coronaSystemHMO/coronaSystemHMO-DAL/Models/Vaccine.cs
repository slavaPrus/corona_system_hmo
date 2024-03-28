using System;
using System.Collections.Generic;

namespace coronaSystemHMO_DAL.Models
{
    public partial class Vaccine
    {
        public int VaccineId { get; set; }
        public int? MemberId { get; set; }
        public DateTime? VaccinationDate { get; set; }
        public string? Manufacturer { get; set; }

        public virtual Member? Member { get; set; }
    }
}
