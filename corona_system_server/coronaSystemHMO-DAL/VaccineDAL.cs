using coronaSystemHMO_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coronaSystemHMO_DAL
{
    public class VaccineDAL : IVaccineDAL
    {
        private readonly coronaSystemHMO_DBContext _context = new coronaSystemHMO_DBContext();

        public async Task<IEnumerable<Vaccine>> GetVaccinesByMemberIdAsync(int memberId)
        {
            return await _context.Vaccines
                .Where(v => v.MemberId == memberId)
                .ToListAsync();
        }

        public async Task AddVaccineByMemberIdAsync(Vaccine vaccine)
        {
            _context.Vaccines.Add(vaccine);
            await _context.SaveChangesAsync();
        }
    }
}
