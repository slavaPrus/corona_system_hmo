using coronaSystemHMO_DTO;

namespace coronaSystemHMO_BL
{
    public interface IVaccineBL
    {
        Task AddVaccineByMemberIdAsync(VaccineDTO vaccineDTO);
        Task<IEnumerable<VaccineDTO>> GetVaccinesByMemberIdAsync(int memberId);
    }
}