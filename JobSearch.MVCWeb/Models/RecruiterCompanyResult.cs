using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobSearch.MVCWeb.Models
{
    public class RecruiterCompanyResult
    {
        public long ClientCompanyID { get; set; }
        public long RecruiterCompanyID { get; set; }
        public string ClientName { get; set; }
        public string RecruiterName { get; set; }
    }
}