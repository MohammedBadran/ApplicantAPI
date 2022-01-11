using Applicant.Domain;
using Applicant.DTO;
using Applicant.Repository.Interface;
using Applicant.Service.Interface;
using AutoMapper;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Applicant.Service
{
    public class ApplciantAppService : IApplciantAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _clientFactory;
        public ApplciantAppService(IUnitOfWork unitOfWork, IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _clientFactory = httpClientFactory;
        }
        public void AddApplciant(ApplicantDto applciantDto)
        {
            var applicant=_mapper.Map<ApplicantDto, Applicants>(applciantDto);
             _unitOfWork.Repository<Applicants>().Add(applicant);
            _unitOfWork.Commit();
        }

        public void DeleteApplciant(int id)
        {
            _unitOfWork.Repository<Applicants>().Delete(id);
            _unitOfWork.Commit();
        }

        public List<ApplicantDto> GetApplicantList()
        {
            var result =_unitOfWork.Repository<Applicants>().GetAll().ToList();
            var applicants = _mapper.Map<List<Applicants>,List<ApplicantDto>>(result);
            return applicants;

        }

        public void UpdateApplciant(ApplicantDto applciantDto)
        {
            var applicant = _mapper.Map<ApplicantDto, Applicants>(applciantDto);

            _unitOfWork.Repository<Applicants>().Update(applicant);
            _unitOfWork.Commit();
        }

        public async Task<bool>  ValidateCountryName(string countryName)
        {
            // todo .. handle url to be genric 
            var request = new HttpRequestMessage(HttpMethod.Get, $"http://api.countrylayer.com/v2/name/{countryName}?access_key=a1b20bc18f2d0927eea1818e32dcda17& FullText =true");
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            return response.StatusCode==System.Net.HttpStatusCode.OK?true:false;
        }
    }
}
