 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunPro.CW2._9987.DAL
{
    public class ApplicantList
    {
        public List<Applicants> GetAllApplicants()
        {
            return new ApplicantManager().GetAllApplicants();
        }

        public List<Applicants> Sort(ByAttribute attribute)
        {
            // sorting the applicants by score using LINQ
            return GetAllApplicants().OrderBy(applicant => applicant.Score).ToList();        
        }

        public List<Applicants> Search (int id, ByAttribute attribute)
        {
            // searching applicants by ID
            return GetAllApplicants().Where(applicant => applicant.Score.Equals(id)).ToList();            
        }

    }
}
