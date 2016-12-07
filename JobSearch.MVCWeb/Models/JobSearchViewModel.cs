using System.Collections.Generic;

namespace JobSearch.MVCWeb.Models
{
    public class JobSearchViewModel
    {
        public Company Company { get; set; }

        public Industry Industry { get; set; }

        public RecruiterCompany RecruiterCompany { get; set; }

        public RecruiterCompanyResult RecruiterCompanyResult { get; set; }

        public IEnumerable<Company> ActiveClientCompanies { get; set; }

        public IEnumerable<Company> ActiveRecruiterCompanies { get; set; }
    }
}