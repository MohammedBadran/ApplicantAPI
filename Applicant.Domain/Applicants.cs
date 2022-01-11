using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicant.Domain
{
    public class Applicants
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
        [Required]
        [MinLength(5)]
        public string FamilyName { get; set; }
        [Required]
        [MinLength(10)]
        public string Address { get; set; }
        [Required]
        public string CountryOfOrigin { get; set; }
        public string EMailAdress { get; set; }
        [Required]
        public int Age { get; set; }
        public bool Hired { get; set; }

    }
}
