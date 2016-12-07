using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JobSearch.MVCWeb.Models
{
    [MetadataType(typeof(InterviewLogMetaData))]
    public partial class InterviewLog
    {
        
    }

    internal class InterviewLogMetaData
    {
        [Required]
        public int InterviewId { get; set; }

        [Required]
        [DisplayName("Company")]
        public long ClientCompanyId { get; set; }

        [Required]
        [DisplayName("Recruiter")]
        public long RecruiterCompanyId { get; set; }

        [Required]
        public int JobId { get; set; }

        [Required]
        [DisplayName("Interview Status")]
        public byte InterviewStatusId { get; set; }

        [Required]
        [DisplayName("Interview Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMMM dd yyyy}")]
        public System.DateTime InterviewDate { get; set; }

        [Required]
        [DisplayName("Interview Time")]
        public string InterviewTime { get; set; }

        [Required]
        public string Notes { get; set; }
        
    }
}