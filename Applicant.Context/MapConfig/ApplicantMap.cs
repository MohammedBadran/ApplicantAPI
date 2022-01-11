using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Applicant.Context.MapConfig
{
    public class ApplicantMap
    {
        //Case we have constraints 
        public ApplicantMap(EntityTypeBuilder<Domain.Applicants> entityBuilder)
        {
            
        }
    }
   
}
