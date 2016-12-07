using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JobSearch.MVCWeb.Models;

namespace JobSearch.MVCWeb.Classes
{
    public class CompanyType
    {
        private JobSearchEntities1 db = new JobSearchEntities1();

        public CompanyType()
        {

        }

        public IEnumerable<RecruiterCompanyResult> GetAssociatedCompanies(string companyType)
        {
            IEnumerable<RecruiterCompanyResult> result = null;

            if (companyType == "ClientCompany")
            {
                result = from rc in db.RecruiterCompany
                         join cc in db.Company on rc.ClientCompanyID equals cc.CompanyId
                         join r in db.Company on rc.RecruiterCompanyID equals r.CompanyId
                         orderby cc.CompanyName
                         select new RecruiterCompanyResult
                                    {
                                        RecruiterCompanyID = rc.RecruiterCompanyID,
                                        ClientCompanyID = rc.ClientCompanyID,
                                        ClientName = cc.CompanyName,
                                        RecruiterName = r.CompanyName
                                    };
            }
            else if (companyType == "RecruiterCompany")
            {
                result = from rc in db.RecruiterCompany
                         join cc in db.Company on rc.ClientCompanyID equals cc.CompanyId
                         join r in db.Company on rc.RecruiterCompanyID equals r.CompanyId
                         orderby r.CompanyName
                         select new RecruiterCompanyResult
                                    {
                                        RecruiterCompanyID = rc.RecruiterCompanyID,
                                        ClientCompanyID = rc.ClientCompanyID,
                                        ClientName = cc.CompanyName,
                                        RecruiterName = r.CompanyName
                                    };
            }

            return result;
        }

        public SelectList LoadAllActiveClientCompanies()
        {
            var activeClientCompanies =
                db.Company.Where(c => c.IsActive && c.IndustryId != 1).OrderBy(c => c.CompanyName).Select(c => new
                                                                                                                   {
                                                                                                                       c
                                                                                                                   .
                                                                                                                   CompanyId,
                                                                                                                       c
                                                                                                                   .
                                                                                                                   CompanyName
                                                                                                                   });
            var activeClientCompanyList = new SelectList(activeClientCompanies, "CompanyId", "CompanyName");
            return activeClientCompanyList;
        }

        public SelectList LoadAllActiveRecruiterCompanies()
        {
            var activeRecruiterCompanies =
                db.Company.Where(c => c.IsActive && c.IndustryId == 1).OrderBy(c => c.CompanyName).Select(c => new
                                                                                                                   {
                                                                                                                       c
                                                                                                                   .
                                                                                                                   CompanyId,
                                                                                                                       c
                                                                                                                   .
                                                                                                                   CompanyName
                                                                                                                   });
            var activeRecruiterCompanyList = new SelectList(activeRecruiterCompanies, "CompanyId", "CompanyName");
            return activeRecruiterCompanyList;
        }

    }
}