using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JobSearch.MVCWeb.Models
{
    [MetadataType(typeof(CompanyMetaData))]
    public partial class Company
    {
        
    }

    internal class CompanyMetaData
    {
        [Required]
        [DisplayName("Company")]
        public string CompanyName { get; set; }

        [Required]
        [DisplayName("Industry")]
        public int IndustryId { get; set; }

        [Required]
        [DisplayName("Address")]
        public string CompanyAddress { get; set; }

        [Required]
        [DisplayName("City")]
        public string CompanyCity { get; set; }

        [Required]
        [DisplayName("State")]
        public string CompanyState { get; set; }

        [Required]
        [DisplayName("Zip")]
        public string CompanyZip { get; set; }

        [Required]
        [DisplayName("Contact Person")]
        public string CompanyContact1Name { get; set; }

        [Required]
        [DisplayName("Title")]
        public string CompanyContact1Title { get; set; }

        [Required]
        [DisplayName("Office Phone")]
        public string CompanyContact1OfficePhone { get; set; }

        [DisplayName("Cell Phone")]
        public string CompanyContact1MobilePhone { get; set; }

        [Required]
        [DisplayName("Email")]
        public string CompanyContact1Email { get; set; }

        [DisplayName("Website")]
        public string CompanyWebsiteUrl { get; set; }

        [DisplayName("Notes")]
        public string Notes { get; set; }

        [DisplayName("Directions")]
        public string DrivingDirections { get; set; }

        [Required]
        [DisplayName("Active")]
        [DefaultValue(true)]
        public bool IsActive { get; set; }
    }
}