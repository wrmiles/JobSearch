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
    public class IndustryController : Controller
    {
        private JobSearchEntities1 db = new JobSearchEntities1();

        //
        // GET: /Industry/

        public ViewResult Index()
        {
            return View(db.Industry.ToList());
        }

        //
        // GET: /Industry/Details/5

        public ViewResult Details(int id)
        {
            Industry industry = db.Industry.Find(id);
            return View(industry);
        }

        //
        // GET: /Industry/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Industry/Create

        [HttpPost]
        public ActionResult Create(Industry industry)
        {
            if (ModelState.IsValid)
            {
                db.Industry.Add(industry);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(industry);
        }
        
        //
        // GET: /Industry/Edit/5
 
        public ActionResult Edit(int id)
        {
            Industry industry = db.Industry.Find(id);
            return View(industry);
        }

        //
        // POST: /Industry/Edit/5

        [HttpPost]
        public ActionResult Edit(Industry industry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(industry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(industry);
        }

        //
        // GET: /Industry/Delete/5
 
        public ActionResult Delete(int id)
        {
            Industry industry = db.Industry.Find(id);
            return View(industry);
        }

        //
        // POST: /Industry/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Industry industry = db.Industry.Find(id);
            db.Industry.Remove(industry);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}