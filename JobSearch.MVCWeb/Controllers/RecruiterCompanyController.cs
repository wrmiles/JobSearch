using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using JobSearch.MVCWeb.Classes;
using JobSearch.MVCWeb.Models;

namespace JobSearch.MVCWeb.Controllers
{ 
    public class RecruiterCompanyController : Controller
    {
        private JobSearchEntities1 db = new JobSearchEntities1();
        private CompanyType companyType = new CompanyType();

        //
        // GET: /RecruiterCompany/

        public ViewResult Index(string sortBy)
        {
            IEnumerable<RecruiterCompanyResult> result = companyType.GetAssociatedCompanies("ClientCompany");

            if (TempData["SortBy"] != null)
            {
                sortBy = TempData["SortBy"].ToString();
            }

            if(sortBy != null)
            {
                result = companyType.GetAssociatedCompanies(sortBy);
            }
            return View(result.ToList());
        }

        

        [HttpPost]
        public ActionResult Sort(string sortBy)
        {
            TempData["SortBy"] = sortBy;
            return RedirectToAction("Index", "RecruiterCompany", new { id = sortBy });
        }

        //
        // GET: /RecruiterCompany/Details/5

        public ViewResult Details(long id)
        {
            RecruiterCompany recruitercompany = db.RecruiterCompany.Find(id);
            return View(recruitercompany);
        }

        //
        // GET: /RecruiterCompany/Create

        

        public ActionResult Create()
        {
            // ddlActiveClientCompanies
            ViewData["ddlActiveClientCompanies"] = companyType.LoadAllActiveClientCompanies();

            // ddlActiveRecruiterCompanies
            ViewData["ddlActiveRecruiterCompanies"] = companyType.LoadAllActiveRecruiterCompanies();
            
            return View();
        } 

        //
        // POST: /RecruiterCompany/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            RecruiterCompany recruiterCompany = new RecruiterCompany();

            if (ModelState.IsValid)
            {
                var selectedClientCompanyId = collection["ddlActiveClientCompanies"];
                var selectedRecruiterCompanyId = collection["ddlActiveRecruiterCompanies"];
                
                recruiterCompany.ClientCompanyID = Convert.ToInt64(selectedClientCompanyId);
                recruiterCompany.RecruiterCompanyID = Convert.ToInt64(selectedRecruiterCompanyId);
                db.RecruiterCompany.Add(recruiterCompany);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(recruiterCompany);
        }
        
        //
        // GET: /RecruiterCompany/Edit/5
 
        public ActionResult Edit(long id)
        {
            RecruiterCompany recruitercompany = db.RecruiterCompany.Find(id);
            return View(recruitercompany);
        }

        //
        // POST: /RecruiterCompany/Edit/5

        [HttpPost]
        public ActionResult Edit(RecruiterCompany recruitercompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recruitercompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(recruitercompany);
        }

        //
        // GET: /RecruiterCompany/Delete/5
 
        public ActionResult Delete(long id)
        {
            RecruiterCompany recruitercompany = db.RecruiterCompany.Find(id);
            return View(recruitercompany);
        }

        //
        // POST: /RecruiterCompany/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {            
            RecruiterCompany recruitercompany = db.RecruiterCompany.Find(id);
            db.RecruiterCompany.Remove(recruitercompany);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult ClientIndex(long recruiterId)
        {
            var result = from rc in db.RecruiterCompany
                     join cc in db.Company on rc.ClientCompanyID equals cc.CompanyId
                     join r in db.Company on rc.RecruiterCompanyID equals r.CompanyId
                     where rc.RecruiterCompanyID == recruiterId
                     orderby cc.CompanyName
                     select new RecruiterCompanyResult
                     {
                         RecruiterCompanyID = rc.RecruiterCompanyID,
                         RecruiterName = r.CompanyName,
                         ClientCompanyID = rc.ClientCompanyID,
                         ClientName = cc.CompanyName
                     };

            return View(result.ToList());
        }

        public ActionResult RecruiterIndex(long clientCompanyId)
        {
            var result = from rc in db.RecruiterCompany
                         join cc in db.Company on rc.ClientCompanyID equals cc.CompanyId
                         join r in db.Company on rc.RecruiterCompanyID equals r.CompanyId
                         where rc.ClientCompanyID == clientCompanyId
                         orderby cc.CompanyName
                         select new RecruiterCompanyResult
                         {
                             RecruiterCompanyID = rc.RecruiterCompanyID,
                             RecruiterName = r.CompanyName,
                             ClientCompanyID = rc.ClientCompanyID,
                             ClientName = cc.CompanyName
                         };

            return View(result.ToList());
        }
    }
}