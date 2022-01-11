using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicant.DTO
{
    public class ApplicantDto
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Min Length for Name is 5 chars")]
        public string Name { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Min Length for FamilyName is 5 chars")]
        public string FamilyName { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Min Length for Address is 10 chars")]
        public string Address { get; set; }
        //[Required]
        public string CountryOfOrigin { get; set; }
        [EmailAddress(ErrorMessage = "Email formate is not valid")]
        public string EMailAdress { get; set; }
        [Required]
        [Range(20,60, ErrorMessage="Age should be bettween 20 and 60")]
        public int Age { get; set; }
        public bool Hired { get; set; }
    }
}
