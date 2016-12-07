using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JobSearch.MVCWeb.Models
{
    [MetadataType(typeof(RecruiterCompanyMetaData))]
    public partial class RecruiterCompany
    {
    }

    internal class RecruiterCompanyMetaData
    {
        [Required]
        [DisplayName("Client Company")]
        public long ClientCompanyID { get; set; }

        [Required]
        [DisplayName("Recruiter")]
        public long RecruiterCompanyID { get; set; }

        
    }
}