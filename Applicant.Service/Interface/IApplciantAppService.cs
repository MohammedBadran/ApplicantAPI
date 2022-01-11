using Applicant.Domain;
using Applicant.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Applicant.Service.Interface
{
    public interface IApplciantAppService
    {
        void AddApplciant(ApplicantDto applciant);
        void DeleteApplciant(int id);
        void UpdateApplciant(ApplicantDto applicant);
        List<ApplicantDto> GetApplicantList();
        Task<bool> ValidateCountryName(string countryName);

    }
}
