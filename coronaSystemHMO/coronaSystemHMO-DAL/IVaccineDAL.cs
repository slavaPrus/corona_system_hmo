using coronaSystemHMO_DAL.Models;

namespace coronaSystemHMO_DAL
{
    public interface IVaccineDAL
    {
        Task AddVaccineByMemberIdAsync(Vaccine vaccine);
        Task<IEnumerable<Vaccine>> GetVaccinesByMemberIdAsync(int memberId);


    }
}