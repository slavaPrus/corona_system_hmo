using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coronaSystemHMO_DTO
{
    public class VaccineDTO
    {
        public int VaccineId { get; set; }
        public int? MemberId { get; set; }
        public DateTime? VaccinationDate { get; set; }
        public string? Manufacturer { get; set; }
    }
}
