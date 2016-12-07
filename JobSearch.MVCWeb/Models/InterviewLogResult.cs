using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSearch.MVCWeb.Models
{
    public class InterviewLogResult
    {
        public int InterviewId { get; set; }
        public long ClientCompanyId { get; set; }
        public long RecruiterCompanyId { get; set; }
        public int JobId { get; set; }
        public string JobTitle { get; set; }
        public byte InterviewStatusId { get; set; }
        public string InterviewStatusDescription { get; set; }
        public System.DateTime InterviewDate { get; set; }
        public string InterviewTime { get; set; }
        public string Notes { get; set; }
        public string ClientName { get; set; }
        public string RecruiterName { get; set; }
    }
}