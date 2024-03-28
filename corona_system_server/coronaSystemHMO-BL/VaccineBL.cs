using AutoMapper;
using coronaSystemHMO_DAL.Models;
using coronaSystemHMO_DAL;
using coronaSystemHMO_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coronaSystemHMO_BL
{
    public class VaccineBL : IVaccineBL
    {
        private readonly IVaccineDAL _vaccineDAL;
        private readonly IMapper _mapper;

        public VaccineBL(IVaccineDAL vaccineDAL, IMapper mapper)
        {
            _vaccineDAL = vaccineDAL ?? throw new ArgumentNullException(nameof(vaccineDAL));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<VaccineDTO>> GetVaccinesByMemberIdAsync(int memberId)
        {
            try
            {
                var vaccines = await _vaccineDAL.GetVaccinesByMemberIdAsync(memberId);
                return _mapper.Map<IEnumerable<VaccineDTO>>(vaccines);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw;
            }
        }

        public async Task AddVaccineByMemberIdAsync(VaccineDTO vaccineDTO)
        {
            try
            {
                var vaccine = _mapper.Map<Vaccine>(vaccineDTO);
                await _vaccineDAL.AddVaccineByMemberIdAsync(vaccine);
            }
            catch (Exception ex)
            {
                // Log the exception
                throw;
            }
        }

       
    }
}
