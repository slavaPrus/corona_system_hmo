using coronaSystemHMO_DTO;

namespace coronaSystemHMO_BL
{
    public interface IMemberBL
    {
        Task<IEnumerable<MemberDTO>> GetAllMembersAsync();
        Task AddMemberAsync(MemberDTO memberDTO);
        Task DeleteMemberAsync(int memberId);
        Task<MemberDTO> GetMemberByIdAsync(int memberId);
        Task UpdateMemberAsync(MemberDTO memberDTO);
    }
}