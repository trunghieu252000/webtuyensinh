using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WikiCollege.Models.Dao;
namespace WikiCollege.Controllers
{
    public class DaiHocController : Controller
    {
        // GET: DaiHoc
        public ActionResult Index(int page = 1, int pageSize = 5)
        {
            var dao = new CollegeDao();
            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }
    }
}