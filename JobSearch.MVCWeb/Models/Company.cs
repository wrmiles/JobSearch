//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobSearch.MVCWeb.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Company
    {
        public Company()
        {
            this.Job = new HashSet<Job>();
        }
    
        public long CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int IndustryId { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyState { get; set; }
        public string CompanyZip { get; set; }
        public string CompanyContact1Name { get; set; }
        public string CompanyContact1Title { get; set; }
        public string CompanyContact1OfficePhone { get; set; }
        public string CompanyContact1MobilePhone { get; set; }
        public string CompanyContact1Email { get; set; }
        public string CompanyWebsiteUrl { get; set; }
        public string Notes { get; set; }
        public string DrivingDirections { get; set; }
        public bool IsActive { get; set; }
    
        public virtual Industry Industry { get; set; }
        public virtual ICollection<Job> Job { get; set; }
    }
}
