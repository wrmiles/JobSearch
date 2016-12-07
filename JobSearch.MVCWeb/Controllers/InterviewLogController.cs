using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSearch.MVCWeb.Classes;
using JobSearch.MVCWeb.Models;

namespace JobSearch.MVCWeb.Controllers
{ 
    public class InterviewLogController : Controller
    {
        private JobSearchEntities1 db = new JobSearchEntities1();
        private CompanyType companyType = new CompanyType();

        //
        // GET: /InterviewLog/

        public ViewResult Index()
        {
            IEnumerable<InterviewLogResult> interviewlogResults = null;

            interviewlogResults = from i in db.InterviewLog
                     join ist in db.InterviewStatus on i.InterviewStatusId equals ist.InterviewStatusId
                     join j in db.Job on i.JobId equals j.JobId
                     join cc in db.Company on i.ClientCompanyId equals cc.CompanyId
                     join r in db.Company on i.RecruiterCompanyId equals r.CompanyId
                     orderby i.InterviewDate, cc.CompanyName
                     select new InterviewLogResult
                     {
                         InterviewId = i.InterviewId,
                         JobId = i.JobId,
                         JobTitle = j.JobTitle,
                         InterviewStatusId = i.InterviewStatusId,
                         InterviewStatusDescription = ist.InterviewStatusDescription,
                         InterviewDate = i.InterviewDate,
                         InterviewTime = i.InterviewTime,
                         Notes = i.Notes,
                         RecruiterCompanyId = i.RecruiterCompanyId,
                         ClientCompanyId = i.ClientCompanyId,
                         ClientName = cc.CompanyName,
                         RecruiterName = r.CompanyName
                     };
                

                    //old var interviewlog = db.InterviewLog.Include(i => i.InterviewStatus).Include(i => i.Job);
            return View(interviewlogResults.ToList());
        }

        //
        // GET: /InterviewLog/Details/5

        public ViewResult Details(int id)
        {
            InterviewLog interviewlog = db.InterviewLog.Find(id);
            return View(interviewlog);
        }

        //
        // GET: /InterviewLog/Create

        public ActionResult Create()
        {
            // ddlActiveClientCompanies
            ViewData["ddlActiveClientCompanies"] = companyType.LoadAllActiveClientCompanies();

            // ddlActiveRecruiterCompanies
            ViewData["ddlActiveRecruiterCompanies"] = companyType.LoadAllActiveRecruiterCompanies();

            ViewBag.InterviewStatusId = new SelectList(db.InterviewStatus, "InterviewStatusId", "InterviewStatusDescription");
            ViewBag.JobId = new SelectList(db.Job, "JobId", "JobTitle");
            return View();
        } 

        //
        // POST: /InterviewLog/Create

        [HttpPost]
        public ActionResult Create(InterviewLog interviewlog, int ddlActiveClientCompanies, int ddlActiveRecruiterCompanies)
        {
            if (ModelState.IsValid)
            {
                interviewlog.ClientCompanyId = ddlActiveClientCompanies;
                interviewlog.RecruiterCompanyId = ddlActiveRecruiterCompanies;
                db.InterviewLog.Add(interviewlog);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }
            ViewBag.InterviewStatusId = new SelectList(db.InterviewStatus, "InterviewStatusId", "InterviewStatusDescription", interviewlog.InterviewStatusId);
            ViewBag.JobId = new SelectList(db.Job, "JobId", "JobTitle", interviewlog.JobId);
            return View(interviewlog);
        }
        
        //
        // GET: /InterviewLog/Edit/5
 
        public ActionResult Edit(int id)
        {
            InterviewLog interviewlog = db.InterviewLog.Find(id);
            // FILL AND PRESELECT DROP DOWN LISTS
            ViewBag.ClientCompanyId = new SelectList(companyType.GetAssociatedCompanies("ClientCompany"), "ClientCompanyID", "ClientName", interviewlog.ClientCompanyId);
            ViewBag.RecruiterCompanyId = new SelectList(companyType.GetAssociatedCompanies("RecruiterCompany"), "RecruiterCompanyID", "RecruiterName", interviewlog.RecruiterCompanyId);
            ViewBag.InterviewStatusId = new SelectList(db.InterviewStatus, "InterviewStatusId", "InterviewStatusDescription", interviewlog.InterviewStatusId);
            ViewBag.JobId = new SelectList(db.Job, "JobId", "JobTitle", interviewlog.JobId);
            return View(interviewlog);
        }

        //
        // POST: /InterviewLog/Edit/5

        [HttpPost]
        public ActionResult Edit(InterviewLog interviewlog, int clientCompanyID, int recruiterCompanyID)
        {
            if (ModelState.IsValid)
            {
                interviewlog.ClientCompanyId = clientCompanyID;
                interviewlog.RecruiterCompanyId = recruiterCompanyID;   

                db.Entry(interviewlog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientCompanyId = new SelectList(companyType.GetAssociatedCompanies("ClientCompany"), "ClientCompanyID", "ClientName", interviewlog.ClientCompanyId);
            ViewBag.RecruiterCompanyId = new SelectList(companyType.GetAssociatedCompanies("RecruiterCompany"), "RecruiterCompanyID", "RecruiterName", interviewlog.RecruiterCompanyId);
            ViewBag.InterviewStatusId = new SelectList(db.InterviewStatus, "InterviewStatusId", "InterviewStatusDescription", interviewlog.InterviewStatusId);
            ViewBag.JobId = new SelectList(db.Job, "JobId", "JobTitle", interviewlog.JobId);
            return View(interviewlog);
        }

        //
        // GET: /InterviewLog/Delete/5
 
        public ActionResult Delete(int id)
        {
            InterviewLog interviewlog = db.InterviewLog.Find(id);
            return View(interviewlog);
        }

        //
        // POST: /InterviewLog/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            InterviewLog interviewlog = db.InterviewLog.Find(id);
            //db.InterviewLog.Remove(interviewlog);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}