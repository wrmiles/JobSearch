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
    public class CompanyController : Controller
    {
        private JobSearchEntities1 db = new JobSearchEntities1();

        //
        // GET: /Company/

        public ViewResult Index(int? industryId)
        {
            ViewBag.IndustryId = new SelectList(db.Industry, "IndustryId", "IndustryName").OrderBy(i => i.Text);
            var company = db.Company.Include(c => c.Industry).Where(c => c.IsActive).OrderBy(c => c.CompanyName);
            if (TempData["FilterByIndustry"] != null)
            {
                industryId = Convert.ToInt32(TempData["FilterByIndustry"]);
                company = db.Company.Include(c => c.Industry).Where(c => c.IsActive && c.IndustryId == industryId).OrderBy(c => c.CompanyName);
            }

            
            return View(company.ToList());
        }

        //
        // GET: /Company/Details/5

        public ViewResult Details(long id)
        {
            Company company = db.Company.Find(id);
            ViewBag.IndustryId = new SelectList(db.Industry, "IndustryId", "IndustryName", company.IndustryId);
            
            return View(company);
        }

        //
        // GET: /Company/Create

        public ActionResult Create()
        {
            ViewBag.IndustryId = new SelectList(db.Industry, "IndustryId", "IndustryName");
            return View();
        } 

        //
        // POST: /Company/Create

        [HttpPost]
        public ActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
                db.Company.Add(company);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.IndustryId = new SelectList(db.Industry, "IndustryId", "IndustryName", company.IndustryId);
            return View(company);
        }
        
        //
        // GET: /Company/Edit/5
 
        public ActionResult Edit(long id)
        {
            Company company = db.Company.Find(id);
            ViewBag.IndustryId = new SelectList(db.Industry, "IndustryId", "IndustryName", company.IndustryId);
            return View(company);
        }

        //
        // POST: /Company/Edit/5

        [HttpPost]
        public ActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IndustryId = new SelectList(db.Industry, "IndustryId", "IndustryName", company.IndustryId);
            return View(company);
        }

        //
        // GET: /Company/Delete/5
 
        public ActionResult Delete(long id)
        {
            Company company = db.Company.Find(id);
            return View(company);
        }

        //
        // POST: /Company/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {            
            Company company = db.Company.Find(id);
            //db.Company.Remove(company);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [HttpPost]
        public ActionResult FilterByIndustry(int industryId)
        {
            TempData["FilterByIndustry"] = industryId;
            return RedirectToAction("Index");
        }
    }
}