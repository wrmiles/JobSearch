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
    
    public partial class JobStatus
    {
        public JobStatus()
        {
            this.Job = new HashSet<Job>();
        }
    
        public byte JobStatusId { get; set; }
        public string JobStatusDescription { get; set; }
    
        public virtual ICollection<Job> Job { get; set; }
    }
}