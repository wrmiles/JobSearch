using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSearch.MVCWeb.Models;

namespace JobSearch.MVCWeb.Controllers
{ 
    public class JobController : Controller
    {
        private JobSearchEntities1 db = new JobSearchEntities1();

        //
        // GET: /Job/

        public ViewResult Index()
        {
            var job = db.Job.Include(j => j.Company).Include(j => j.JobStatus).Where(j => j.Company.IndustryId != 1 && j.Company.IsActive);
            return View(job.ToList());
        }

        //
        // GET: /Job/Details/5

        public ViewResult Details(int id)
        {
            Job job = db.Job.Find(id);
            return View(job);
        }

        //
        // GET: /Job/Create

        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(ActiveClientCompanies(), "CompanyId", "CompanyName");
            ViewBag.JobStatusId = new SelectList(db.JobStatus, "JobStatusId", "JobStatusDescription");
            return View();
        } 

        //
        // POST: /Job/Create

        [HttpPost]
        public ActionResult Create(Job job)
        {
            if (ModelState.IsValid)
            {
                db.Job.Add(job);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.CompanyId = new SelectList(ActiveClientCompanies(), "CompanyId", "CompanyName", job.CompanyId);
            ViewBag.JobStatusId = new SelectList(db.JobStatus, "JobStatusId", "JobStatusDescription", job.JobStatusId);
            return View(job);
        }
        
        //
        // GET: /Job/Edit/5
 
        public ActionResult Edit(int id)
        {
            Job job = db.Job.Find(id);
            ViewBag.CompanyId = new SelectList(ActiveClientCompanies(), "CompanyId", "CompanyName", job.CompanyId).Where(c => c.Value != "1").OrderBy(c => c.Text);
            ViewBag.JobStatusId = new SelectList(db.JobStatus, "JobStatusId", "JobStatusDescription", job.JobStatusId);
            return View(job);
        }

        //
        // POST: /Job/Edit/5

        [HttpPost]
        public ActionResult Edit(Job job)
        {
            if (ModelState.IsValid)
            {
                db.Entry(job).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(ActiveClientCompanies(), "CompanyId", "CompanyName", job.CompanyId);
            ViewBag.JobStatusId = new SelectList(db.JobStatus, "JobStatusId", "JobStatusDescription", job.JobStatusId);
            return View(job);
        }

        //
        // GET: /Job/Delete/5
 
        public ActionResult Delete(int id)
        {
            Job job = db.Job.Find(id);
            return View(job);
        }

        //
        // POST: /Job/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Job job = db.Job.Find(id);
            db.Job.Remove(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        private IEnumerable<Company> ActiveClientCompanies()
        {
            var activeClientCompanies = db.Company.Where(c => c.CompanyId != 1 && c.IsActive).OrderBy(c => c.CompanyName).ToList();
            return activeClientCompanies;
        }
    }
}