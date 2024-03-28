using coronaSystemHMO_DAL.Models;

namespace coronaSystemHMO_DAL
{
    public interface IMemberDAL
    {
        Task<IEnumerable<Member>> GetAllMembersAsync();
        Task AddMemberAsync(Member member);
        Task DeleteMemberAsync(int memberId);
        Task<Member> GetMemberByIdAsync(int memberId);
        Task UpdateMemberAsync(Member member);

    }
}