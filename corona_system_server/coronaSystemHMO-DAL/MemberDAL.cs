using coronaSystemHMO_DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coronaSystemHMO_DAL
{
    public class MemberDAL : IMemberDAL

    {
        private readonly coronaSystemHMO_DBContext _context = new coronaSystemHMO_DBContext();

        public async Task<IEnumerable<Member>> GetAllMembersAsync()
        {
            try
            {
                return await _context.Members
                    .Include(m => m.Vaccines)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception
                throw;
            }
        }

        public async Task<Member> GetMemberByIdAsync(int memberId)
        {
            return await _context.Members
                .Include(m => m.Vaccines)
                .FirstOrDefaultAsync(m => m.MemberId == memberId);
        }

        public async Task AddMemberAsync(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMemberAsync(Member member)
        {
            _context.Members.Update(member);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMemberAsync(int memberId)
        {
            var memberToDelete = await GetMemberByIdAsync(memberId);
            if (memberToDelete != null)
            {
                _context.Members.Remove(memberToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
