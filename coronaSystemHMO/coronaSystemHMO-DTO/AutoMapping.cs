using AutoMapper;
using coronaSystemHMO_DAL.Models;

namespace coronaSystemHMO_DTO
{
    public class AutoMapping:Profile
    {
        public AutoMapping() {
           
            CreateMap<Member,MemberDTO>();
            CreateMap<MemberDTO, Member>();
            CreateMap<Vaccine, VaccineDTO>();
            CreateMap<VaccineDTO, Vaccine>();

        }
    }
}
