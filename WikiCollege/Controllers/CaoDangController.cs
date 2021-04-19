using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WikiCollege.Models.Dao;

namespace WikiCollege.Controllers
{
    public class CaoDangController : Controller
    {
        // GET: CaoDang
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new CollegeDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
    }
}