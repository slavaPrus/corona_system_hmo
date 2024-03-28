using coronaSystemHMO_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace coronaSystemHMO_DTO
{
    public class MemberDTO
    {
        public int MemberId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? IdNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? StreetNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Phone { get; set; }
        public string? MobilePhone { get; set; }
        public DateTime? PositiveTestDate { get; set; }
        public DateTime? RecoveryDate { get; set; }
        public byte[]? Image { get; set; }
        public ICollection<VaccineDTO> Vaccines { get; set; }
    }
}
