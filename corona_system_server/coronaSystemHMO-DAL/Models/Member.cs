using System;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace coronaSystemHMO_DAL.Models
{
    public partial class Member
    {
        public Member()
        {
            Vaccines = new HashSet<Vaccine>();
        }

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

        public byte[]? Image {  get; set; }

        public virtual ICollection<Vaccine> Vaccines { get; set; }
    }
}
