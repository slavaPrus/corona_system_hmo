using System;
using System.Threading.Tasks;
using AutoMapper;
using coronaSystemHMO_DAL;
using coronaSystemHMO_DAL.Models;
using coronaSystemHMO_DTO;

namespace coronaSystemHMO_BL
{
    public class MemberBL : IMemberBL
    {
        private readonly IMemberDAL _memberDAL;
        private readonly IMapper _mapper;

        public MemberBL(IMemberDAL memberDAL, IMapper mapper)
        {
            _memberDAL = memberDAL ?? throw new ArgumentNullException(nameof(memberDAL));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<MemberDTO>> GetAllMembersAsync()
        {
            try
            {
                var members = await _memberDAL.GetAllMembersAsync();
                return _mapper.Map<IEnumerable<MemberDTO>>(members);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw;
            }
        }
       


        public async Task<MemberDTO> GetMemberByIdAsync(int memberId)
        {
            try
            {
                var member = await _memberDAL.GetMemberByIdAsync(memberId);
                return _mapper.Map<MemberDTO>(member);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw;
            }
        }

        public async Task AddMemberAsync(MemberDTO memberDTO)
        {
            try
            {
                var member = _mapper.Map<Member>(memberDTO);
                await _memberDAL.AddMemberAsync(member);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw;
            }
        }

        public async Task UpdateMemberAsync(MemberDTO memberDTO)
        {
            try
            {
                var member = _mapper.Map<Member>(memberDTO);
                await _memberDAL.UpdateMemberAsync(member);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw;
            }
        }

        public async Task DeleteMemberAsync(int memberId)
        {
            try
            {
                await _memberDAL.DeleteMemberAsync(memberId);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw;
            }
        }
    }
}