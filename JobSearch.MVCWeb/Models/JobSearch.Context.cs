﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class JobSearchEntities1 : DbContext
    {
        public JobSearchEntities1()
            : base("name=JobSearchEntities1")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Industry> Industry { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<RecruiterCompany> RecruiterCompany { get; set; }
        public DbSet<InterviewLog> InterviewLog { get; set; }
        public DbSet<InterviewStatus> InterviewStatus { get; set; }
        public DbSet<JobStatus> JobStatus { get; set; }
        public DbSet<Job> Job { get; set; }
    }
}
