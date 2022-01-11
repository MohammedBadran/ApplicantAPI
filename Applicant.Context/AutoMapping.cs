using Applicant.Domain;
using Applicant.DTO;
using AutoMapper;

namespace Applicant.Context
{
    public class AutoMapping : Profile
    {

        public AutoMapping()
        {
            CreateMap<ApplicantDto, Applicants>();
            CreateMap<Applicants, ApplicantDto>();
        }

    }
}
